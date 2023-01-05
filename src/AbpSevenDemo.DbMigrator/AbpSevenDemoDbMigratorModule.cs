using AbpSevenDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpSevenDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpSevenDemoEntityFrameworkCoreModule),
    typeof(AbpSevenDemoApplicationContractsModule)
)]
public class AbpSevenDemoDbMigratorModule : AbpModule
{

}
