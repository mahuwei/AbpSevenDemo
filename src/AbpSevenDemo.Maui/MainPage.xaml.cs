using AbpSevenDemo.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui;

public partial class MainPage : ContentPage, ITransientDependency
{
    public MainPage(
		MainPageViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}