using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using avaloniaAotTemplate.Views;

namespace avaloniaAotTemplate;

public partial class App : Application
{
    // 声明一个全局的 DI 容器实例
    public static Composition AppComposition { get; } = new Composition();
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = AppComposition.RootViewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}