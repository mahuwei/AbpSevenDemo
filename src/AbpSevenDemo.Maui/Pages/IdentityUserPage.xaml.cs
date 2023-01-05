using AbpSevenDemo.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui.Pages;

public partial class IdentityUserPage : ContentPage, ITransientDependency
{
	public IdentityUserPage(IdentityUserPageViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        if(BindingContext is IOnAppearing vm)
        {
            await vm.OnAppearingAsync();
        }
    }
}