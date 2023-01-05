using Microsoft.EntityFrameworkCore;

namespace AbpSevenDemo.EntityFrameworkCore;

public class AbpSevenDemoTenantDbContextFactory :
    AbpSevenDemoDbContextFactoryBase<AbpSevenDemoTenantDbContext>
{
    protected override AbpSevenDemoTenantDbContext CreateDbContext(
        DbContextOptions<AbpSevenDemoTenantDbContext> dbContextOptions)
    {
        return new AbpSevenDemoTenantDbContext(dbContextOptions);
    }
}
