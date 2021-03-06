Language Feature Status
=====

This document reflects the status, and planned work in progress, for the compiler team.  It is a live document
and will be updated as work progresses, features are added / removed, and as work on feature progresses.
This is not an exhaustive list of our features but rather the ones which have active development
efforts behind them.

# C# 7.3

| Feature | Branch | State | Developers | Reviewer | LDM Champ |
| ------- | ------ | ----- | ---------- | -------- | --------- |
| [Support == and != for tuples](https://github.com/dotnet/csharplang/issues/190) | [tuple-equality](https://github.com/dotnet/roslyn/tree/features/tuple-equality) | In Progress | [jcouv](https://github.com/jcouv) | [AlekseyTs](https://github.com/AlekseyTs) | [jcouv](https://github.com/jcouv) |
| strongname | master | Merged | [tyoverby](https://github.com/tyoverby) | [agocke](https://github.com/agocke) | [jaredpar](https://github.com/jaredpar) |
| [Attribute on backing field](https://github.com/dotnet/csharplang/issues/42) | features/compiler | Merged | [jcouv](https://github.com/jcouv) | [AlekseyTs](https://github.com/AlekseyTs) | [jcouv](https://github.com/jcouv) |
| Ref Reassignment | [ref-reassignment](https://github.com/dotnet/roslyn/tree/features/ref-reassignment) | In Progress | [agocke](https://github.com/agocke) | [vsadov](https://github.com/vsadov) | [jarepdar](https://github.com/jaredpar) |
| Constraints | [constraints](https://github.com/dotnet/roslyn/tree/features/constraints) | In Progress | [OmarTawfik](https://github.com/OmarTawfik) | [vsadov](https://github.com/vsadov) | [jarepdar](https://github.com/jaredpar) |
| [Stackalloc initializers](https://github.com/dotnet/csharplang/issues/1286) | [stackalloc-init](https://github.com/dotnet/roslyn/tree/features/stackalloc-init) | In Progress | [alrz](https://github.com/alrz) | [vsadov](https://github.com/vsadov) | [jcouv](https://github.com/jcouv) |
| [Custom fixed](https://github.com/dotnet/csharplang/issues/1314) | [custom-fixed](https://github.com/dotnet/roslyn/tree/features/custom-fixed) | In Progress | [vsadov](https://github.com/vsadov) | [jcouv](https://github.com/jcouv) | [jarepdar](https://github.com/jaredpar) |
| [Improved overload candidates](https://github.com/dotnet/csharplang/issues/98) | features/compiler | In Progress | [gafter](https://github.com/gafter) | [cston](https://github.com/cston) | [mattwar](https://github.com/mattwar) |
| [Expression variables](https://github.com/dotnet/csharplang/blob/master/proposals/expression-variables-in-initializers.md) | [features/ExpressionVariables](https://github.com/dotnet/roslyn/tree/features/ExpressionVariables) | In Progress | [AlekseyTs](https://github.com/AlekseyTs) | [gafter](https://github.com/gafter) | [gafter](https://github.com/gafter) |

# C# 8.0

| Feature | Branch | State | Developers | Reviewer | LDM Champ |
| ------- | ------ | ----- | ---------- | -------- | --------- |
| [Default Interface Methods](https://github.com/dotnet/csharplang/blob/master/proposals/default-interface-methods.md) | [defaultInterfaceImplementation](https://github.com/dotnet/roslyn/tree/features/DefaultInterfaceImplementation) | Prototype | [AlekseyTs](https://github.com/AlekseyTs) | [gafter](https://github.com/gafter) | [gafter](https://github.com/gafter) |
| [Nullable reference type](https://github.com/dotnet/csharplang/blob/master/proposals/nullable-reference-types.md) | [NullableReferenceTypes](https://github.com/dotnet/roslyn/tree/features/NullableReferenceTypes) | Prototype | [cston](https://github.com/cston), [AlekseyTs](https://github.com/AlekseyTs) | [333fred](https://github.com/333fred) | [mattwar](https://github.com/mattwar) |
| [Recursive patterns](https://github.com/dotnet/csharplang/blob/master/proposals/patterns.md) | [recursive-patterns](https://github.com/dotnet/roslyn/tree/features/recursive-patterns) | Prototype | [gafter](https://github.com/gafter) | [agocke](https://github.com/agocke), [cston](https://github.com/cston) | [gafter](https://github.com/gafter) |
| [Async streams](https://github.com/dotnet/csharplang/blob/master/proposals/async-streams.md) | [async-streams](https://github.com/dotnet/roslyn/tree/features/async-streams) | In Progress | [jcouv](https://github.com/jcouv) |  [OmarTawfik](https://github.com/OmarTawfik) | [stephentoub](https://github.com/stephentoub) |
| [Caller expression attribute](https://github.com/dotnet/csharplang/issues/287) | TBD | Prototype | [alrz](https://github.com/alrz) | [jcouv](https://github.com/jcouv) | [jcouv](https://github.com/jcouv) |
| [Target-typed new](https://github.com/dotnet/csharplang/issues/100) | TBD | Prototype | [alrz](https://github.com/alrz) | TBD | [jcouv](https://github.com/jcouv) |
| [Generic attributes](https://github.com/dotnet/csharplang/issues/124) | [generic-attributes](https://github.com/dotnet/roslyn/tree/features/generic-attributes) | In Progress | [AviAvni](https://github.com/AviAvni) | TBD | [mattwar](https://github.com/mattwar) |
| [Ranges](https://github.com/dotnet/roslyn/blob/features/range/docs/features/range.md) | [range](https://github.com/dotnet/roslyn/tree/features/range) | In Progress | [OmarTawfik](https://github.com/OmarTawfik) | [vsadov](https://github.com/vsadov) | [jaredpar](https://github.com/jaredpar) |

# C# 7.1

| Feature | Branch | State | Developers | Reviewer | LDM Champ |
| ------- | ------ | ----- | ---------- | -------- | --------- |
| [Async Main](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.1/async-main.md) | master | Merged | [tyoverby](https://github.com/tyoverby) | [vsadov](https://github.com/vsadov) | [stephentoub](https://github.com/stephentoub) |
| [Default Expressions](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.1/target-typed-default.md) | master  | Merged | [jcouv](https://github.com/jcouv) | [cston](https://github.com/cston) | [jcouv](https://github.com/jcouv) |
| [Ref Assemblies](https://github.com/dotnet/roslyn/blob/master/docs/features/refout.md) | master | Merged (IDE and project-system integrations ongoing) | [jcouv](https://github.com/jcouv) | [gafter](https://github.com/gafter) | N/A |
| [Infer tuple names](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.1/infer-tuple-names.md) | master | Merged | [jcouv](https://github.com/jcouv) | [gafter](https://github.com/gafter) | [jcouv](https://github.com/jcouv) |
| [Pattern-matching with generics](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.1/generics-pattern-match.md) | master  | Merged | [gafter](https://github.com/gafter) | [agocke](https://github.com/agocke) | [gafter](https://github.com/gafter) |

# C# 7.2

| Feature | Branch | State | Developers | Reviewer | LDM Champ |
| ------- | ------ | ----- | ---------- | -------- | --------- |
| [ref readonly](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/readonly-ref.md) | master | Merged | [vsadov](https://github.com/vsadov), [OmarTawfik](https://github.com/OmarTawfik) | [cston](https://github.com/cston),[gafter](https://github.com/gafter) | [jaredpar](https://github.com/jaredpar) |
| [interior pointer/Span<T>/ref struct](https://github.com/dotnet/csharplang/pull/264) | master | Merged | [vsadov](https://github.com/vsadov) | [gafter](https://github.com/gafter), [jaredpar](https://github.com/jaredpar) | [jaredpar](https://github.com/jaredpar) |
| [non-trailing named arguments](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/non-trailing-named-arguments.md) | master | Merged | [jcouv](https://github.com/jcouv) | [gafter](https://github.com/gafter) | [jcouv](https://github.com/jcouv) |
| [private protected](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/private-protected.md) | master | Merged | [gafter](https://github.com/gafter) | [jcouv](https://github.com/jcouv) | [gafter](https://github.com/gafter) |
| [conditional ref operator](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/conditional-ref.md) | master | Merged | [vsadov](https://github.com/vsadov) | [cston](https://github.com/cston) | [jaredpar](https://github.com/jaredpar) |
| [Digit separator after base specifier](https://github.com/dotnet/roslyn/pull/20449) | master | Merged | [alrz](https://github.com/alrz) | | [gafter](https://github.com/gafter) |

# C# 7.2 fixes
| Feature | Branch | State | Developers | Reviewer | LDM Champ |
| ------- | ------ | ----- | ---------- | -------- | --------- |
| [`ref` and `this` ordering in ref extension](https://github.com/dotnet/roslyn/pull/23643) |  | Merged | [alrz](https://github.com/alrz) |  |  |
| [Tiebreaker for by-val and `in` overloads](https://github.com/dotnet/roslyn/pull/23122) | master | Merged | [OmarTawfik](https://github.com/OmarTawfik) |  | |

# FAQ

- **Is target version a guarantee?**: No.  It's explicitly not a guarantee.  This is just the planned and ongoing work to the best of our knowledge at this time.
- **Where are these State values defined?**: Take a look at the [Developing a Language Feature](contributing/Developing%20a%20Language%20Feature.md) document.
