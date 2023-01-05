using AbpSevenDemo.Maui.Pages;
using AbpSevenDemo.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui;

public partial class AppShell : Shell, ITransientDependency
{
    public AppShell(ShellViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();

        Routing.RegisterRoute(nameof(IdentityUserCreateModalPage), typeof(IdentityUserCreateModalPage));
        Routing.RegisterRoute(nameof(IdentityUserEditModalPage), typeof(IdentityUserEditModalPage));
    }
}
