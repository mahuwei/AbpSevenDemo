using Volo.Abp.Modularity;

namespace AbpSevenDemo;

[DependsOn(
    typeof(AbpSevenDemoApplicationModule),
    typeof(AbpSevenDemoDomainTestModule)
    )]
public class AbpSevenDemoApplicationTestModule : AbpModule
{

}
