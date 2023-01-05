using AbpSevenDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpSevenDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpSevenDemoController : AbpControllerBase
{
    protected AbpSevenDemoController()
    {
        LocalizationResource = typeof(AbpSevenDemoResource);
    }
}
