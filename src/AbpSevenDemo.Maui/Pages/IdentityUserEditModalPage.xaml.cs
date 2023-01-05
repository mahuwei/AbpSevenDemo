using AbpSevenDemo.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui.Pages;

public partial class IdentityUserEditModalPage : ContentPage, ITransientDependency
{
	public IdentityUserEditModalPage(IdentityUserEditViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}