using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using AbpSevenDemo.Maui.Messages;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AbpSevenDemo.Maui.ViewModels;

[QueryProperty("UserId", "UserId")]
public partial class IdentityUserEditViewModel : AbpSevenDemoViewModelBase, ITransientDependency
{
    protected IIdentityUserAppService IdentityUserAppService { get; }

    [ObservableProperty]
    IdentityUserDto user;

    public IdentityUserEditViewModel(IIdentityUserAppService identityUserAppService)
    {
        IdentityUserAppService = identityUserAppService;

        User = new IdentityUserDto();
    }

    public async void GetUserAsync()
    {
        User = await IdentityUserAppService.GetAsync(Guid.Parse(UserId));
    }

    [ObservableProperty]
    public string userId;

    partial void OnUserIdChanged(string value)
    {
        GetUserAsync();
    }

    [RelayCommand]
    async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task Edit()
    {
        WeakReferenceMessenger.Default.Send(new IdentityUserEditMessage(new IdentityUserEditMessageArgs
        {
            UserId = Guid.Parse(UserId),
            User = new IdentityUserUpdateDto
            {
                UserName = User.UserName,
                Name = User.Name,
                Email = User.Email,
                Surname = User.Surname,
                PhoneNumber = User.PhoneNumber,
                LockoutEnabled = User.LockoutEnabled,
                IsActive = User.IsActive,
                ConcurrencyStamp = User.ConcurrencyStamp
            }
        }));
        await Shell.Current.GoToAsync("..");
    }
}
