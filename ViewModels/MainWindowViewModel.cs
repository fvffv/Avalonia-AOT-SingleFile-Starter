using avaloniaAotTemplate.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace avaloniaAotTemplate.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string title;
    /// <summary>
    /// 保留默认构造函数用于开发阶段预览界面静态读取数据
    /// </summary>
    public MainWindowViewModel()
    {
        
    }

    /// <summary>
    /// 演示静态依赖注入
    /// </summary>
    /// <param name="testService"></param>
    public MainWindowViewModel(TestService testService)
    {
        Title = testService.Test();
    }
}