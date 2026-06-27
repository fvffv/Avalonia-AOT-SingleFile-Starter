using avaloniaAotTemplate.Services;
using avaloniaAotTemplate.ViewModels;
using Pure.DI;

namespace avaloniaAotTemplate;

public partial class Composition
{
    private void Setup() => DI.Setup(nameof(Composition))
        .Bind<TestService>().As(Lifetime.Singleton).To<TestService>()
        .Root<MainWindowViewModel>("RootViewModel");
}