# Avalonia-AOT-SingleFile-Starter

中文 | [English](#english)

## 中文

`Avalonia-AOT-SingleFile-Starter` 是一个基于 **Avalonia 12** 和 **.NET 10** 整合的桌面应用模板，目标是开箱即用地发布 **Windows x64** 和 **Linux x64** 单文件 NativeAOT 程序。

模板已经内置 Windows 和 Linux 两个平台所需的 Skia / HarfBuzz 静态库链接配置，并在 Rider 中预置了 `win64` 与 `Linux64` 两个单文件 AOT 发布配置，适合作为 Avalonia NativeAOT 项目的起始工程。

### 重要提示

不要直接克隆当前仓库作为完整模板使用。

由于 Skia / HarfBuzz 静态库文件体积较大，仓库源码可能不会完整包含全部二进制静态库。请在 **Releases** 页面下载完整模板压缩包。

### 模板特性

- 基于 `net10.0` 和 Avalonia 12。
- 支持 Windows x64 单文件 NativeAOT 发布。
- 支持 Linux x64 单文件 NativeAOT 发布。
- 内置 Windows / Linux 的 SkiaSharp 与 HarfBuzzSharp 静态库。
- Linux 下已配置 `libSkiaSharp.a`、`libHarfBuzzSharp.a` 以及相关系统库链接项。
- Windows 下已配置 Skia / HarfBuzz / ANGLE 相关静态库链接项。
- Rider 中已预置发布到文件夹配置：`win64` 和 `Linux64`。
- 已加入一组常用且更适合 NativeAOT / Trim 场景的基础包。
- NativeAOT 静态链接配置已拆分到 `StaticLibrary` 目录中，减少项目根节点中的无效文件提示。

### 目录说明

```text
avaloniaAotTemplate/
  avaloniaAotTemplate.slnx
  .idea/                                      Rider 配置
  avaloniaAotTemplate/
    avaloniaAotTemplate.csproj
    StaticLibrary/
      Linux/
        libSkiaSharp.a
        libHarfBuzzSharp.a
        NativeAotStaticLink.props
      Windows/
        SkiaSharp.lib
        skia.lib
        libHarfBuzzSharp.lib
        av_libglesv2.lib
        NativeAotStaticLink.props
```

`StaticLibrary/Linux/NativeAotStaticLink.props` 和 `StaticLibrary/Windows/NativeAotStaticLink.props` 负责声明 NativeAOT 所需的静态链接项。主项目文件只负责导入对应平台的配置。

### Rider 发布配置

模板已在 Rider 中配置好两个发布项：

- `win64`：发布 Windows x64 单文件自包含程序。
- `Linux64`：发布 Linux x64 单文件自包含程序。

发布配置启用了单文件、自包含、裁剪等选项。Linux 发布时会静态链接 `libSkiaSharp.a` 和 `libHarfBuzzSharp.a`，发布目录不会再额外携带 `libSkiaSharp.so` 与 `libHarfBuzzSharp.so`。

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

这些包是为了常见桌面应用开发场景预置的基础组合。NativeAOT 对反射、动态代码生成和未声明序列化类型更敏感，后续新增第三方包时建议优先选择支持 Trim / AOT 的库。

### 命令行发布示例

Windows x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true
```

Linux x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true
```

### 注意事项

- Linux 版本已经静态链接 SkiaSharp 与 HarfBuzzSharp，但仍可能依赖系统图形和基础库，例如 `libGL`、`libEGL`、`fontconfig`、`freetype`、`libpng`、`libjpeg`、`libwebp` 等。
- Windows 版本内置对应静态库配置，但发布环境仍需要匹配 .NET 10 SDK 和 NativeAOT 工具链。
- 编译 / 发布对应平台的程序仍建议在对应平台上进行：Windows x64 请在 Windows 环境发布，Linux x64 请在 Linux 环境发布。推荐使用 Rider 中已经预置好的 `win64` 和 `Linux64` 发布配置。
- 如果 Rider 项目树中曾经显示 `png`、`GL`、`libSkiaSharp` 等黄色感叹号，重新加载项目即可。相关链接项已经移动到 `StaticLibrary/*/NativeAotStaticLink.props` 并设置为隐藏。

### 获取完整模板

请不要直接克隆当前仓库来使用模板。

受限于静态库文件大小，完整可用模板请前往 **Releases** 下载。

## English

`Avalonia-AOT-SingleFile-Starter` is a desktop application starter template based on **Avalonia 12** and **.NET 10**. It is designed to publish ready-to-use **Windows x64** and **Linux x64** single-file NativeAOT applications.

The template includes preconfigured Skia / HarfBuzz static library linking for both Windows and Linux. It also includes Rider publish configurations for `win64` and `Linux64`, making it a practical starting point for Avalonia NativeAOT applications.

### Important Notice

Do not clone this repository directly if you need the complete template.

Because the Skia / HarfBuzz static libraries are large, the repository source may not contain all required binary static libraries. Please download the complete template archive from the **Releases** page.

### Features

- Based on `net10.0` and Avalonia 12.
- Supports Windows x64 single-file NativeAOT publishing.
- Supports Linux x64 single-file NativeAOT publishing.
- Includes SkiaSharp and HarfBuzzSharp static libraries for Windows and Linux.
- Linux linking is configured for `libSkiaSharp.a`, `libHarfBuzzSharp.a`, and required system libraries.
- Windows linking is configured for Skia / HarfBuzz / ANGLE related static libraries.
- Rider publish-to-folder configurations are included: `win64` and `Linux64`.
- Includes a set of commonly used packages that are more suitable for NativeAOT / Trim scenarios.
- NativeAOT static linking configuration is split into the `StaticLibrary` directory to keep the project tree cleaner.

### Project Layout

```text
avaloniaAotTemplate/
  avaloniaAotTemplate.slnx
  .idea/                                      Rider settings
  avaloniaAotTemplate/
    avaloniaAotTemplate.csproj
    StaticLibrary/
      Linux/
        libSkiaSharp.a
        libHarfBuzzSharp.a
        NativeAotStaticLink.props
      Windows/
        SkiaSharp.lib
        skia.lib
        libHarfBuzzSharp.lib
        av_libglesv2.lib
        NativeAotStaticLink.props
```

`StaticLibrary/Linux/NativeAotStaticLink.props` and `StaticLibrary/Windows/NativeAotStaticLink.props` declare the static linking items required by NativeAOT. The main project file only imports the platform-specific configuration.

### Rider Publish Configurations

The template includes two Rider publish configurations:

- `win64`: publishes a Windows x64 single-file self-contained application.
- `Linux64`: publishes a Linux x64 single-file self-contained application.

The publish configurations enable single-file, self-contained, and trimming options. On Linux, `libSkiaSharp.a` and `libHarfBuzzSharp.a` are linked statically, so the publish directory does not need to carry `libSkiaSharp.so` or `libHarfBuzzSharp.so`.

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

These packages are included as a practical baseline for common desktop application development. NativeAOT is more sensitive to reflection, dynamic code generation, and undeclared serialization types, so additional dependencies should preferably support Trim / AOT.

### Command-Line Publish Examples

Windows x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true
```

Linux x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true
```

### Notes

- The Linux build statically links SkiaSharp and HarfBuzzSharp, but it may still depend on system graphics and base libraries such as `libGL`, `libEGL`, `fontconfig`, `freetype`, `libpng`, `libjpeg`, and `libwebp`.
- The Windows build includes the corresponding static library configuration, but the publishing environment still needs a matching .NET 10 SDK and NativeAOT toolchain.
- Publishing for each target platform is still recommended on the corresponding platform: publish Windows x64 builds on Windows, and Linux x64 builds on Linux. Using the preconfigured Rider publish profiles `win64` and `Linux64` is recommended.
- If Rider previously showed yellow warning entries such as `png`, `GL`, or `libSkiaSharp` in the project tree, reload the project. These linking items have been moved to `StaticLibrary/*/NativeAotStaticLink.props` and marked as hidden.

### Download the Complete Template

Do not clone this repository directly to use the template.

Because of static library file size limits, please download the complete usable template from **Releases**.
