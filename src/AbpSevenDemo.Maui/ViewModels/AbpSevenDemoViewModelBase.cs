using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using AbpSevenDemo.Maui.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace AbpSevenDemo.Maui.ViewModels;

public abstract partial class AbpSevenDemoViewModelBase : ObservableObject
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; }

    public ICurrentTenant CurrentTenant => LazyServiceProvider.LazyGetRequiredService<ICurrentTenant>();

    public ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();
    
    public LocalizationResourceManager L => LazyServiceProvider.LazyGetRequiredService<LocalizationResourceManager>();
}