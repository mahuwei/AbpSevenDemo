using AbpSevenDemo.Localization;
using Volo.Abp.Application.Services;

namespace AbpSevenDemo;

/* Inherit your application services from this class.
 */
public abstract class AbpSevenDemoAppService : ApplicationService
{
    protected AbpSevenDemoAppService()
    {
        LocalizationResource = typeof(AbpSevenDemoResource);
    }
}
