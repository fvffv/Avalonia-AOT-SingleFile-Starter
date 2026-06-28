# Avalonia-AOT-SingleFile-Starter

中文 | [English](#english)

## 中文

`Avalonia-AOT-SingleFile-Starter` 是一个基于 **Avalonia 12** 和 **.NET 10** 的桌面应用启动模板，用于快速创建支持单文件 NativeAOT 发布的 Avalonia 项目。

模板通过 [`greepar/StaticLink.Avalonia`](https://github.com/greepar/StaticLink.Avalonia) 集成 Avalonia / Skia / HarfBuzz 相关静态 native libraries，适用于 Windows、Linux 和 macOS 的单文件 NativeAOT 发布场景。

### 特性

- 基于 `net10.0` 和 Avalonia 12。
- 支持 Windows x64 单文件 NativeAOT 发布。
- 支持 Linux x64 / Linux arm64 单文件 NativeAOT 发布。
- 支持 macOS x64 / macOS arm64 单文件 NativeAOT 发布。
- 使用 `StaticLink.Avalonia` 提供跨平台静态 native libraries。
- Rider 中预置 `win64` 与 `Linux64` 发布配置。
- 包含 AOT 安全 JSON 源生成示例。
- 包含 Refit API 调用模板示例。
- 包含 FluentValidation 表单验证示例。
- 包含 Pure.DI 编译期依赖注入示例。
- 预置常用且更适合 NativeAOT / Trim 场景的基础包。

### 目录说明

```text
avalonia-aot/
  avaloniaAotTemplate.slnx
  .idea/                         Rider 配置
  avaloniaAotTemplate/
    avaloniaAotTemplate.csproj
    App.axaml
    Program.cs
    Composition.cs
    Models/
    Services/
    ViewModels/
    Views/
```

### 静态链接相关包

| 包名 | 作用 |
| --- | --- |
| `StaticLink.Avalonia` | 为 Avalonia 单文件 NativeAOT 发布提供跨平台静态 native libraries。 |
| `StaticLink.Avalonia.Native` | 为 Avalonia Native 相关场景提供静态资源支持。 |

### Rider 发布配置

模板已在 Rider 中配置好两个发布项：

- `win64`：发布 Windows x64 单文件自包含 NativeAOT 程序。
- `Linux64`：发布 Linux x64 单文件自包含 NativeAOT 程序。

macOS 发布可通过命令行执行，或在 Rider 中新增对应的 `osx-x64` / `osx-arm64` 发布配置。

### 已集成的主要 NuGet 包

| 包名 | 作用 |
| --- | --- |
| `Avalonia` | Avalonia UI 框架核心包。 |
| `Avalonia.Desktop` | 桌面端启动和平台集成支持。 |
| `Avalonia.Themes.Fluent` | Avalonia 官方 Fluent 风格主题。 |
| `Avalonia.Fonts.Inter` | 内置 Inter 字体资源。 |
| `Avalonia.Controls.ItemsRepeater` | 高性能列表 / 重复项布局控件支持。 |
| `AsyncImageLoader.Avalonia` | Avalonia 图片异步加载支持，适合列表、头像、远程图片等场景。 |
| `AvaloniaUI.DiagnosticsSupport` | Avalonia 调试诊断支持，Release 配置中已排除。 |
| `CommunityToolkit.Mvvm` | 常用 MVVM 工具包，提供源生成器、命令、通知属性等能力。 |
| `FluentValidation` | 模型和表单验证库。 |
| `Irihi.Ursa` | Avalonia 组件库，提供更丰富的常用 UI 控件。 |
| `Irihi.Ursa.Themes.Semi` | Ursa 的 Semi 风格主题包。 |
| `Pure.DI` | 编译期依赖注入方案，减少运行时反射，更适合 AOT 场景。 |
| `Refit` | 声明式 HTTP API 客户端，用于接口请求封装。 |
| `StaticLink.Avalonia` | Avalonia 单文件 NativeAOT 静态 native libraries 支持。 |
| `StaticLink.Avalonia.Native` | Avalonia Native 静态资源支持。 |

NativeAOT 对反射、动态代码生成和未声明序列化类型更敏感，后续新增第三方包时建议优先选择支持 Trim / AOT 的库。

### 命令行发布示例

Windows x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux arm64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-arm64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

macOS x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r osx-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

macOS arm64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r osx-arm64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

### 注意事项

- 编译 / 发布对应平台的程序建议在对应平台上进行：Windows 在 Windows 环境发布，Linux 在 Linux 环境发布，macOS 在 macOS 环境发布。
- 推荐使用 Rider 中预置的 `win64` 和 `Linux64` 发布配置；macOS 可按需新增 `osx-x64` / `osx-arm64` 发布配置。
- Linux 目标系统可能仍需要基础图形库或运行环境库，例如 `libGL`、`libEGL`、`fontconfig`、`freetype` 等。

## English

`Avalonia-AOT-SingleFile-Starter` is a desktop application starter template based on **Avalonia 12** and **.NET 10**. It helps create Avalonia projects that are ready for single-file NativeAOT publishing.

The template uses [`greepar/StaticLink.Avalonia`](https://github.com/greepar/StaticLink.Avalonia) to integrate Avalonia / Skia / HarfBuzz related static native libraries for Windows, Linux, and macOS single-file NativeAOT publishing.

### Features

- Based on `net10.0` and Avalonia 12.
- Supports Windows x64 single-file NativeAOT publishing.
- Supports Linux x64 / Linux arm64 single-file NativeAOT publishing.
- Supports macOS x64 / macOS arm64 single-file NativeAOT publishing.
- Uses `StaticLink.Avalonia` for cross-platform static native libraries.
- Includes Rider publish configurations for `win64` and `Linux64`.
- Includes a NativeAOT-safe JSON source generation example.
- Includes a Refit API client template.
- Includes a FluentValidation form validation example.
- Includes a Pure.DI compile-time dependency injection example.
- Includes commonly used packages that are more suitable for NativeAOT / Trim scenarios.

### Project Layout

```text
avalonia-aot/
  avaloniaAotTemplate.slnx
  .idea/                         Rider settings
  avaloniaAotTemplate/
    avaloniaAotTemplate.csproj
    App.axaml
    Program.cs
    Composition.cs
    Models/
    Services/
    ViewModels/
    Views/
```

### Static Linking Packages

| Package | Purpose |
| --- | --- |
| `StaticLink.Avalonia` | Provides cross-platform static native libraries for Avalonia single-file NativeAOT publishing. |
| `StaticLink.Avalonia.Native` | Provides static resource support for Avalonia Native scenarios. |

### Rider Publish Configurations

The template includes two Rider publish configurations:

- `win64`: publishes a Windows x64 single-file self-contained NativeAOT application.
- `Linux64`: publishes a Linux x64 single-file self-contained NativeAOT application.

macOS publishing can be done from the command line, or by adding `osx-x64` / `osx-arm64` publish configurations in Rider.

### Included NuGet Packages

| Package | Purpose |
| --- | --- |
| `Avalonia` | Core Avalonia UI framework package. |
| `Avalonia.Desktop` | Desktop startup and platform integration support. |
| `Avalonia.Themes.Fluent` | Official Avalonia Fluent theme. |
| `Avalonia.Fonts.Inter` | Bundled Inter font resources. |
| `Avalonia.Controls.ItemsRepeater` | High-performance repeated item layout control support. |
| `AsyncImageLoader.Avalonia` | Async image loading support for Avalonia, useful for lists, avatars, and remote images. |
| `AvaloniaUI.DiagnosticsSupport` | Avalonia diagnostics support, excluded from Release builds. |
| `CommunityToolkit.Mvvm` | Common MVVM toolkit with source generators, commands, and observable properties. |
| `FluentValidation` | Model and form validation library. |
| `Irihi.Ursa` | Avalonia component library with additional common UI controls. |
| `Irihi.Ursa.Themes.Semi` | Semi-style theme package for Ursa. |
| `Pure.DI` | Compile-time dependency injection, reducing runtime reflection and fitting AOT scenarios better. |
| `Refit` | Declarative HTTP API client for wrapping service requests. |
| `StaticLink.Avalonia` | Static native libraries support for Avalonia single-file NativeAOT publishing. |
| `StaticLink.Avalonia.Native` | Static resource support for Avalonia Native. |

NativeAOT is more sensitive to reflection, dynamic code generation, and undeclared serialization types, so additional dependencies should preferably support Trim / AOT.

### Command-Line Publish Examples

Windows x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux arm64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-arm64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

macOS x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r osx-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

macOS arm64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r osx-arm64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```


### Notes

- Publishing for each target platform is recommended on the corresponding platform: Windows on Windows, Linux on Linux, and macOS on macOS.
- Using the preconfigured Rider publish profiles `win64` and `Linux64` is recommended; add `osx-x64` / `osx-arm64` publish profiles for macOS as needed.
- Linux target systems may still need base graphics or runtime libraries such as `libGL`, `libEGL`, `fontconfig`, and `freetype`.
