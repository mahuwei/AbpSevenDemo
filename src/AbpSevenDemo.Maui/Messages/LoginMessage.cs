using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AbpSevenDemo.Maui.Messages;
public class LoginMessage : ValueChangedMessage<bool?>
{
    public LoginMessage(bool? value = null) : base(value)
    {
    }
}
