using AbpSevenDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpSevenDemo.Blazor;

public abstract class AbpSevenDemoComponentBase : AbpComponentBase
{
    protected AbpSevenDemoComponentBase()
    {
        LocalizationResource = typeof(AbpSevenDemoResource);
    }
}
