using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpSevenDemo;

[Dependency(ReplaceServices = true)]
public class AbpSevenDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpSevenDemo";
}
