# CLAUDE.md

Guidance for Claude Code when working in this repository.

## Commit messages: always use Conventional Commits

Every commit message in this repo **must** follow the [Conventional Commits](https://www.conventionalcommits.org/) format:

```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```

This is not just a style preference — releases are automated by [release-please](https://github.com/googleapis/release-please) (`.github/workflows/release-please.yml`), which parses commit history to decide the next semantic version, generate `CHANGELOG.md`, and open the release PR. Non-conventional commit messages are invisible to it and will be omitted from the changelog or cause the wrong version bump.

**Types in use here:**
- `feat:` — a new feature (bumps minor version)
- `fix:` — a bug fix (bumps patch version)
- `perf:` — a performance improvement
- `deps:` — dependency updates
- `chore:`, `docs:`, `ci:`, `test:`, `refactor:` — no version bump, excluded/hidden from the changelog

**Breaking changes:** append `!` after the type/scope (e.g. `feat!:`) or add a `BREAKING CHANGE:` footer.
This bumps the major version.

Examples:
```
fix: correct off-by-one error in ReadAllLines position validation
feat: add support for nullable value types in StringPositionAttribute
feat!: rename BuildString to Build, drop the pluralized overloads
```

## Versioning and releases

Do not hand-edit a version number anywhere in this repo. Package versioning is fully derived from git tags:

- [MinVer](https://github.com/adamralph/minver) (wired into `PositionedStrings/PositionedStrings.csproj`) reads the nearest `v*` git tag at build time to set the assembly/package version.
- release-please decides the next tag from Conventional Commits on `main`, opens a release PR, and — once that PR is merged — creates the git tag and GitHub Release.
- A GitHub Release being published (whether created by release-please or manually) triggers `.github/workflows/release.yml`, which packs and pushes to NuGet.org.

## Project shape

- `PositionedStrings/` — the library, SDK-style csproj multi-targeting `netstandard2.0` and `net10.0` (see `docs/decisions/DR-0001-migrate-to-multi-target-netstandard2-0-net10-0.md`).
- `PositionedStrings.Tests/` — xUnit tests, targets `net10.0` only for now.
- `Directory.Build.props` — shared package metadata (authors, license, repo URL) for all projects.
