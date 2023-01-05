using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Data;

/* This is used if database provider does't define
 * IAbpSevenDemoDbSchemaMigrator implementation.
 */
public class NullAbpSevenDemoDbSchemaMigrator : IAbpSevenDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
