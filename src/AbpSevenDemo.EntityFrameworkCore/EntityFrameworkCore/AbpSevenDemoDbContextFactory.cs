using Microsoft.EntityFrameworkCore;

namespace AbpSevenDemo.EntityFrameworkCore;

public class AbpSevenDemoDbContextFactory :
    AbpSevenDemoDbContextFactoryBase<AbpSevenDemoDbContext>
{
    protected override AbpSevenDemoDbContext CreateDbContext(
        DbContextOptions<AbpSevenDemoDbContext> dbContextOptions)
    {
        return new AbpSevenDemoDbContext(dbContextOptions);
    }
}
