using CommunityToolkit.Mvvm.Messaging;
using AbpSevenDemo.Maui.Localization;
using AbpSevenDemo.Maui.Messages;
using AbpSevenDemo.Maui.Oidc;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui.ViewModels;

public class ShellViewModel : AbpSevenDemoViewModelBase, ITransientDependency
{
    public bool IsIdentityUserPageVisible => CurrentUser.IsAuthenticated;

    public string CurrentUserName => L["Welcome"] + $" {CurrentUser.UserName}";

    public ShellViewModel(LocalizationResourceManager localizationManager)
    {
        WeakReferenceMessenger.Default.Register<LoginMessage>(this, (r, m) =>
        {
            UpdateProperties();
        });

        WeakReferenceMessenger.Default.Register<LogoutMessage>(this, (r, m) =>
        {
            UpdateProperties();
        });

        localizationManager.PropertyChanged += (_, _) =>
        {
            UpdateProperties();
        };
    }

    private void UpdateProperties()
    {
        OnPropertyChanged(nameof(IsIdentityUserPageVisible));
        OnPropertyChanged(nameof(CurrentUserName));
    }
}