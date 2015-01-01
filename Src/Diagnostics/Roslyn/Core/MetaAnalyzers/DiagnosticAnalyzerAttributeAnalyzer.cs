﻿using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Roslyn.Diagnostics.Analyzers.MetaAnalyzers
{
    [DiagnosticAnalyzer]
    public sealed class DiagnosticAnalyzerAttributeAnalyzer : DiagnosticAnalyzerCorrectnessAnalyzer
    {
        private static LocalizableString localizableTitleMissingAttribute = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.MissingDiagnosticAnalyzerAttributeTitle), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources));
        private static LocalizableString localizableMessageMissingAttribute = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.MissingAttributeMessage), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources), DiagnosticAnalyzerTypeFullName);

        public static DiagnosticDescriptor MissingDiagnosticAnalyzerAttributeRule = new DiagnosticDescriptor(
            RoslynDiagnosticIds.MissingDiagnosticAnalyzerAttributeRuleId,
            localizableTitleMissingAttribute,
            localizableMessageMissingAttribute,
            "AnalyzerCorrectness",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: false,
            customTags: WellKnownDiagnosticTags.Telemetry);

        private static LocalizableString localizableTitleAddLanguageSupportToAnalyzer = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.AddLanguageSupportToAnalyzerTitle), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources));
        private static LocalizableString localizableMessageAddLanguageSupportToAnalyzer = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.AddLanguageSupportToAnalyzerMessage), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources));

        public static DiagnosticDescriptor AddLanguageSupportToAnalyzerRule = new DiagnosticDescriptor(
            RoslynDiagnosticIds.AddLanguageSupportToAnalyzerRuleId,
            localizableTitleAddLanguageSupportToAnalyzer,
            localizableMessageAddLanguageSupportToAnalyzer,
            "AnalyzerCorrectness",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: false,
            customTags: WellKnownDiagnosticTags.Telemetry);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(MissingDiagnosticAnalyzerAttributeRule, AddLanguageSupportToAnalyzerRule);
            }
        }

        protected override CompilationAnalyzer GetCompilationAnalyzer(Compilation compilation, INamedTypeSymbol diagnosticAnalyzer, INamedTypeSymbol diagnosticAnalyzerAttribute)
        {
            return new AttributeAnalyzer(diagnosticAnalyzer, diagnosticAnalyzerAttribute);
        }

        private sealed class AttributeAnalyzer : CompilationAnalyzer
        {
            private static readonly string csharpCodeAnalysisAssembly = @"Microsoft.CodeAnalysis.CSharp.dll";
            private static readonly string basicCodeAnalysisAssembly = @"Microsoft.CodeAnalysis.VisualBasic.dll";

            public AttributeAnalyzer(INamedTypeSymbol diagnosticAnalyzer, INamedTypeSymbol diagnosticAnalyzerAttribute)
                : base(diagnosticAnalyzer, diagnosticAnalyzerAttribute)
            {
            }

            protected override void AnalyzeDiagnosticAnalyzer(SymbolAnalysisContext symbolContext)
            {
                var namedType = (INamedTypeSymbol)symbolContext.Symbol;
                if (namedType.IsAbstract)
                {
                    return;
                }

                // 1) MissingDiagnosticAnalyzerAttributeRule: DiagnosticAnalyzer has no DiagnosticAnalyzerAttribute.
                // 2) AddLanguageSupportToAnalyzerRule: For analyzer supporting only one of C# or VB languages, detect if it can support the other language.

                var hasAttribute = false;
                var hasMultipleAttributes = false;
                SyntaxNode attributeSyntax = null;
                string supportedLanguage = null;

                var namedTypeAttributes = AttributeHelpers.GetApplicableAttributes(namedType);
                foreach (var attribute in namedTypeAttributes)
                {
                    if (AttributeHelpers.DerivesFrom(attribute.AttributeClass, DiagnosticAnalyzerAttribute))
                    {
                        hasMultipleAttributes |= hasAttribute;
                        hasAttribute = true;

                        if (!hasMultipleAttributes)
                        {
                            foreach (var arg in attribute.ConstructorArguments)
                            {
                                if (arg.Kind == TypedConstantKind.Primitive &&
                                    arg.Type != null &&
                                    arg.Type.SpecialType == SpecialType.System_String)
                                {
                                    supportedLanguage = (string)arg.Value;
                                    attributeSyntax = attribute.ApplicationSyntaxReference.GetSyntax(symbolContext.CancellationToken);
                                }
                            }
                        }
                    }
                }

                if (!hasAttribute)
                {
                    var diagnostic = Diagnostic.Create(MissingDiagnosticAnalyzerAttributeRule, namedType.Locations[0]);
                    symbolContext.ReportDiagnostic(diagnostic);
                }
                else if (!hasMultipleAttributes && supportedLanguage != null)
                {
                    Debug.Assert(attributeSyntax != null);

                    var supportsCSharp = supportedLanguage == LanguageNames.CSharp;
                    var supportsVB = supportedLanguage == LanguageNames.VisualBasic;
                    if (supportsCSharp || supportsVB)
                    {
                        // If the analyzer assembly doesn't reference either C# or VB CodeAnalysis assemblies, 
                        // then the analyzer is pretty likely a language-agnostic analyzer.
                        var assemblyReferenceToCheck = supportsCSharp ? csharpCodeAnalysisAssembly : basicCodeAnalysisAssembly;
                        var referenceFound = false;
                        foreach (var reference in symbolContext.Compilation.References)
                        {
                            if (reference.Display != null)
                            {
                                var fileName = Path.GetFileName(reference.Display);
                                if (fileName.Equals(assemblyReferenceToCheck, StringComparison.OrdinalIgnoreCase))
                                {
                                    referenceFound = true;
                                    break;
                                }
                            }
                        }

                        if (!referenceFound)
                        {
                            var missingLanguage = supportsCSharp ? LanguageNames.VisualBasic : LanguageNames.CSharp;
                            var diagnostic = Diagnostic.Create(AddLanguageSupportToAnalyzerRule, attributeSyntax.GetLocation(), namedType.Name, missingLanguage);
                            symbolContext.ReportDiagnostic(diagnostic);
                        }
                    }
                }
            }
        }
    }
}
