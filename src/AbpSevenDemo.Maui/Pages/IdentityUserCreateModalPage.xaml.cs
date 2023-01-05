using CommunityToolkit.Mvvm.Messaging;
using AbpSevenDemo.Maui.Messages;
using AbpSevenDemo.Maui.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AbpSevenDemo.Maui.Pages;

public partial class IdentityUserCreateModalPage : ContentPage, ITransientDependency
{
    public IdentityUserCreateModalPage(IdentityUserCreateViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}