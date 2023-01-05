using AbpSevenDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpSevenDemo;

[DependsOn(
    typeof(AbpSevenDemoEntityFrameworkCoreTestModule)
    )]
public class AbpSevenDemoDomainTestModule : AbpModule
{

}
