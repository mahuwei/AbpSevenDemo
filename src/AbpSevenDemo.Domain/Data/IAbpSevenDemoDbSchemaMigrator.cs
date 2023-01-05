using System.Threading.Tasks;

namespace AbpSevenDemo.Data;

public interface IAbpSevenDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
