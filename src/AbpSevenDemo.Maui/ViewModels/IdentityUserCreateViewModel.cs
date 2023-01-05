using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using AbpSevenDemo.Maui.Messages;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AbpSevenDemo.Maui.ViewModels;
public partial class IdentityUserCreateViewModel : AbpSevenDemoViewModelBase, ITransientDependency
{
    public IdentityUserCreateDto User { get; } = new();

    [RelayCommand]
    async Task Cancel()
    {
        await Shell.Current.GoToAsync(".."); 
    }

    [RelayCommand]
    async Task Create()
    {
        WeakReferenceMessenger.Default.Send(new IdentityUserCreateMessage(User));
        await Shell.Current.GoToAsync(".."); 
    }
}
