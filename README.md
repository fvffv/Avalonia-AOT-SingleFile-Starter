# Avalonia-AOT-SingleFile-Starter

中文 | [English](#english)

## 中文

`Avalonia-AOT-SingleFile-Starter` 是一个基于 **Avalonia 12** 和 **.NET 10** 的桌面应用启动模板，目标是开箱即用地发布 **Windows x64** 和 **Linux x64** 单文件 NativeAOT 程序。

当前模板已经改为使用 [`greepar/StaticLink.Avalonia`](https://github.com/greepar/StaticLink.Avalonia) 提供 Avalonia / Skia / HarfBuzz 相关静态 native libraries。项目不再内置 `StaticLibrary` 静态库文件夹，也不需要手动维护 `libSkiaSharp.a`、`libHarfBuzzSharp.a`、`SkiaSharp.lib`、`skia.lib` 等二进制文件。

模板在 Rider 中预置了 `win64` 与 `Linux64` 两个单文件 AOT 发布配置，适合作为 Avalonia NativeAOT 项目的起始工程。

### 特性

- 基于 `net10.0` 和 Avalonia 12。
- 支持 Windows x64 单文件 NativeAOT 发布。
- 支持 Linux x64 单文件 NativeAOT 发布。
- 使用 `StaticLink.Avalonia` 包提供静态 native libraries。
- 不再需要项目内置 `StaticLibrary` 目录。
- Rider 中已预置发布到文件夹配置：`win64` 和 `Linux64`。
- 已加入一组常用且更适合 NativeAOT / Trim 场景的基础包。
- 包含 AOT 安全 JSON 源生成示例。
- 包含 Refit API 调用模板示例。
- 包含 FluentValidation 表单验证示例。
- 包含 Pure.DI 编译期依赖注入示例。

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

旧版本中的 `StaticLibrary/Linux` 和 `StaticLibrary/Windows` 目录已经移除。静态链接能力现在由 NuGet 包提供。

### 静态链接相关包

当前项目通过以下包处理 Avalonia 单文件 NativeAOT 的 native 静态链接：

| 包名 | 作用 |
| --- | --- |
| `StaticLink.Avalonia` | 为 Avalonia 单文件 NativeAOT 发布提供静态 native libraries。 |
| `StaticLink.Avalonia.Native` | 当前模板保留的 Avalonia Native 静态资源包引用，用于配合 NativeAOT 静态链接场景。 |

`StaticLink.Avalonia` 的发布命令示例中使用 `PublishAot=true`、`SelfContained=true`、`PublishSingleFile=true` 等参数，并支持按需要选择 `win-x64`、`linux-x64`、`linux-arm64` 等 RID。

### Rider 发布配置

模板已在 Rider 中配置好两个发布项：

- `win64`：发布 Windows x64 单文件自包含 NativeAOT 程序。
- `Linux64`：发布 Linux x64 单文件自包含 NativeAOT 程序。

发布配置启用了单文件、自包含、裁剪等选项。推荐直接使用 Rider 中的预置发布配置完成发布。

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

这些包是为了常见桌面应用开发场景预置的基础组合。NativeAOT 对反射、动态代码生成和未声明序列化类型更敏感，后续新增第三方包时建议优先选择支持 Trim / AOT 的库。

### 命令行发布示例

Windows x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux x64：

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

### 作为项目模板安装

如果你把本项目打包成标准 .NET 模板包，可以使用：

```bash
dotnet new install AvaloniaAot.SingleFile.Starter.Template.1.0.0.nupkg
```

创建新项目：

```bash
dotnet new avalonia-aot-singlefile -n MyAotApp
```

创建时会自动把解决方案名、项目名、命名空间、XAML `x:Class` 和 Rider 配置中的路径替换为你的项目名。安装后也可以在支持 .NET 模板的 IDE 中选择该模板，推荐使用 Rider 打开并使用内置的 `win64` / `Linux64` 发布配置。

### 注意事项

- 编译 / 发布对应平台的程序仍建议在对应平台上进行：Windows x64 请在 Windows 环境发布，Linux x64 请在 Linux 环境发布。
- 推荐使用 Rider 中已经预置好的 `win64` 和 `Linux64` 发布配置。
- Linux 版本即使完成 NativeAOT 单文件发布，也可能仍依赖目标系统中的基础图形库或运行环境库，例如 `libGL`、`libEGL`、`fontconfig`、`freetype` 等。
- 旧版本中手动放置的 `StaticLibrary` 目录已经不再需要。如果你的项目里还保留该目录，可以删除并改用 `StaticLink.Avalonia` 包。
- 如果 Rider 项目树中曾经显示 `png`、`GL`、`libSkiaSharp` 等黄色感叹号，删除旧的 `NativeLibrary` / `NativeSystemLibrary` 手动配置并重新加载项目即可。

## English

`Avalonia-AOT-SingleFile-Starter` is a desktop application starter template based on **Avalonia 12** and **.NET 10**. It is designed to publish ready-to-use **Windows x64** and **Linux x64** single-file NativeAOT applications.

The template now uses [`greepar/StaticLink.Avalonia`](https://github.com/greepar/StaticLink.Avalonia) to provide the Avalonia / Skia / HarfBuzz related static native libraries. The project no longer ships a `StaticLibrary` folder and no longer requires manually maintained binaries such as `libSkiaSharp.a`, `libHarfBuzzSharp.a`, `SkiaSharp.lib`, or `skia.lib`.

The template also includes Rider publish configurations for `win64` and `Linux64`, making it a practical starting point for Avalonia NativeAOT applications.

### Features

- Based on `net10.0` and Avalonia 12.
- Supports Windows x64 single-file NativeAOT publishing.
- Supports Linux x64 single-file NativeAOT publishing.
- Uses `StaticLink.Avalonia` to provide static native libraries.
- No project-local `StaticLibrary` directory is required anymore.
- Rider publish-to-folder configurations are included: `win64` and `Linux64`.
- Includes a set of commonly used packages that are more suitable for NativeAOT / Trim scenarios.
- Includes a NativeAOT-safe JSON source generation example.
- Includes a Refit API client template.
- Includes a FluentValidation form validation example.
- Includes a Pure.DI compile-time dependency injection example.

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

The old `StaticLibrary/Linux` and `StaticLibrary/Windows` directories have been removed. Static linking support is now provided by NuGet packages.

### Static Linking Packages

The project uses the following packages for Avalonia single-file NativeAOT static native linking:

| Package | Purpose |
| --- | --- |
| `StaticLink.Avalonia` | Provides static native libraries for Avalonia single-file NativeAOT publishing. |
| `StaticLink.Avalonia.Native` | Avalonia Native static resource package reference retained by this template for NativeAOT static linking scenarios. |

The `StaticLink.Avalonia` publish example uses `PublishAot=true`, `SelfContained=true`, and `PublishSingleFile=true`, and supports RIDs such as `win-x64`, `linux-x64`, and `linux-arm64`.

### Rider Publish Configurations

The template includes two Rider publish configurations:

- `win64`: publishes a Windows x64 single-file self-contained NativeAOT application.
- `Linux64`: publishes a Linux x64 single-file self-contained NativeAOT application.

The publish configurations enable single-file, self-contained, and trimming options. Using the preconfigured Rider publish profiles is recommended.

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
| `StaticLink.Avalonia.Native` | Avalonia Native static resource support. |

These packages are included as a practical baseline for common desktop application development. NativeAOT is more sensitive to reflection, dynamic code generation, and undeclared serialization types, so additional dependencies should preferably support Trim / AOT.

### Command-Line Publish Examples

Windows x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r win-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

Linux x64:

```bash
dotnet publish avaloniaAotTemplate.csproj -c Release -r linux-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true
```

### Install as a Project Template

If this project is packed as a standard .NET template package, install it with:

```bash
dotnet new install AvaloniaAot.SingleFile.Starter.Template.1.0.0.nupkg
```

Create a new project:

```bash
dotnet new avalonia-aot-singlefile -n MyAotApp
```

The solution name, project name, namespaces, XAML `x:Class`, and Rider configuration paths are replaced with your project name automatically. After installation, the template can also be selected from IDEs that support installed .NET templates. Rider is recommended, especially with the built-in `win64` / `Linux64` publish configurations.

### Notes

- Publishing for each target platform is still recommended on the corresponding platform: publish Windows x64 builds on Windows, and Linux x64 builds on Linux.
- Using the preconfigured Rider publish profiles `win64` and `Linux64` is recommended.
- Even after Linux NativeAOT single-file publishing, the target system may still need base graphics or runtime libraries such as `libGL`, `libEGL`, `fontconfig`, and `freetype`.
- The old manually maintained `StaticLibrary` directory is no longer required. If your project still has it, you can remove it and use the `StaticLink.Avalonia` package instead.
- If Rider previously showed yellow warning entries such as `png`, `GL`, or `libSkiaSharp` in the project tree, remove the old manual `NativeLibrary` / `NativeSystemLibrary` configuration and reload the project.
