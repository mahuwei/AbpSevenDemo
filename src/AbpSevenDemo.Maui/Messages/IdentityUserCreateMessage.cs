using CommunityToolkit.Mvvm.Messaging.Messages;
using Volo.Abp.Identity;

namespace AbpSevenDemo.Maui.Messages;
public class IdentityUserCreateMessage : ValueChangedMessage<IdentityUserCreateDto>
{
    public IdentityUserCreateMessage(IdentityUserCreateDto value) : base(value)
    {
    }
}
