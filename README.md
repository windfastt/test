# UltraCompress

Windows-first file compressor that prioritizes **smallest defensible output** over speed. Phase 1 scaffold: Core contracts, worker CLI with **zstd** and **7z (`7za` subprocess)**, engine service shell, and WinUI tray stub.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows 10/11 for **UltraCompress.Tray** (WinUI 3, Phase 2)
- Linux/macOS can build **Core**, **Worker**, **Engine**, and tests

## Build

```bash
cd src
dotnet restore UltraCompress.sln
dotnet build UltraCompress.sln
```

On non-Windows hosts, build individual projects (tray targets `net8.0-windows`):

```bash
dotnet build src/UltraCompress.Core/UltraCompress.Core.csproj
dotnet build src/UltraCompress.Worker/UltraCompress.Worker.csproj
dotnet test tests/UltraCompress.Core.Tests/UltraCompress.Core.Tests.csproj
```

## CLI

```bash
cd src/UltraCompress.Worker
dotnet run -- compress --input /path/to/file --profile Small
```

Profiles: `Balanced`, `Small`, `Tiny`, `Laboratory`, `Experimental` — see [docs/USER.md](docs/USER.md). **Laboratory** defaults to LZMA2 **7z** via bundled `tools/7z/` (`7za`); see [tools/7z/README.md](tools/7z/README.md) and [docs/legal/THIRD_PARTY_NOTICES.md](docs/legal/THIRD_PARTY_NOTICES.md).

## Projects

| Project | Role |
|---------|------|
| `UltraCompress.Core` | Recipes, fingerprints, backends, profiles |
| `UltraCompress.Worker` | zstd + 7za adapters, round-trip verify, CLI |
| `UltraCompress.Engine` | Windows service host stub |
| `UltraCompress.Tray` | WinUI 3 placeholder |
| `UltraCompress.Core.Tests` | Unit tests |

## CI

GitHub Actions: `dotnet build` + `dotnet test` on `windows-latest`.
