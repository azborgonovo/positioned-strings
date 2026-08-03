---
status: accepted
date: 2026-04-12
decision-makers: Andre Borgonovo
---

# Migrate positioned-strings to multi-target netstandard2.0 + net10.0

## Context and Problem Statement

The PositionedStrings library currently targets an ancient Portable Class Library format (.NET 4.0, Profile328) using the legacy `.csproj` format. This is a significant technical debt that prevents the library from leveraging modern .NET runtime capabilities.

Modern .NET runtime capabilities — particularly `Span<T>` and `ReadOnlySpan<char>` — could meaningfully improve the performance of string parsing and building operations that are central to this library. These APIs are not available in .NET Standard 2.0, which is compatible with .NET Framework.

The challenge is adopting these capabilities to improve performance for modern .NET consumers without breaking existing consumers on .NET Framework who rely on this library.

## Forces and Constraints

- The library is a public NuGet package consumed by both .NET Framework and modern .NET projects.
- Dropping .NET Framework support would break existing consumers.
- The desired performance improvements are purely internal implementation details (no public API surface changes).
- `.NET Standard 2.0` is the highest version compatible with .NET Framework but lacks the modern performance APIs (`Span<T>`, etc.) that motivate the migration.
- `.NET Standard` is in maintenance mode; no new versions are planned beyond 2.1.

## Considered Options

### Option 1: Target .NET Standard 2.0 only

Modernise the project to SDK-style format but target only `netstandard2.0`.

**Pros**
- All consumers (.NET Framework and modern .NET) continue working without changes.
- Simplest build setup — single target, no conditionalised code.

**Cons**
- Cannot use `Span<T>`, `ReadOnlySpan<char>`, or other modern performance APIs.
- Fails to address the core motivation for the migration.

### Option 2: Target .NET 10 only

Drop .NET Framework support and target `net10.0` exclusively.

**Pros**
- Full access to modern runtime and language features.
- Simpler build configuration compared to multi-targeting.

**Cons**
- Breaks all .NET Framework consumers in the new version.
- The gain over multi-targeting is marginal — avoiding dual code paths, a minor benefit for a focused library.

### Option 3: Multi-target netstandard2.0 + net10.0

Ship a single NuGet package targeting both `netstandard2.0` and `net10.0`, with optimized `Span`-based implementations for the modern target.

**Pros**
- .NET Framework consumers continue working with no changes or migration effort.
- Modern .NET consumers benefit from allocation-free, `Span<T>`-based internals.
- No breaking major version required — ecosystem disruption is minimised.
- Public API surface remains identical across both targets.

**Cons**
- Slightly more complex build configuration (multi-targeting in `.csproj`).
- Hot paths require conditionalised implementation code (e.g., `#if NET10_0_OR_GREATER` guards or separate implementation files).

## Decision

In the context of a public NuGet library with both .NET Framework and modern .NET consumers, facing the need to leverage modern runtime capabilities for performance, we decided on **Option 3: multi-target netstandard2.0 + net10.0**, to achieve internal performance improvements using `Span<T>`-based algorithms on modern .NET while retaining full backward compatibility for .NET Framework consumers, accepting the added complexity of conditionalised implementation paths.

### Consequences

The migration enables significant performance improvements on modern .NET targets through allocation-free parsing and building using `Span<T>` and related APIs, while .NET Framework consumers remain unaffected and face no migration burden.

The trade-off is increased build configuration and selective use of conditional compilation in hot paths, which is manageable for a focused, utility-oriented library.

This approach preserves ecosystem compatibility while maximizing performance benefits for consumers who have already modernized to .NET 5 or later.

## More Information

**Implementation approach:**
- Update `.csproj` files to SDK-style format with `<TargetFrameworks>netstandard2.0;net10.0</TargetFrameworks>`.
- Use `#if NET10_0_OR_GREATER` guards in performance-critical sections (e.g., parsing logic) to enable `Span<T>` paths.
- Ensure tests run against both targets to verify compatibility.

**Implementation status:** The SDK-style multi-target project shape (`netstandard2.0;net10.0`)
has been implemented, along with GitHub Actions CI/CD and NuGet.org publishing. The
`Span<T>`-based internals rewrite described above is still open follow-up work — internals are
currently identical across both targets, and the test project only exercises `net10.0`. Once the
Span rewrite lands, the test project should be updated to target both TFMs.
