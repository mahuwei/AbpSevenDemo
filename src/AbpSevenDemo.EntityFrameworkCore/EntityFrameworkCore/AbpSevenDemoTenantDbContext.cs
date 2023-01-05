using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace AbpSevenDemo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AbpSevenDemoTenantDbContext : AbpSevenDemoDbContextBase<AbpSevenDemoTenantDbContext>
{
    public AbpSevenDemoTenantDbContext(DbContextOptions<AbpSevenDemoTenantDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetMultiTenancySide(MultiTenancySides.Tenant);

        base.OnModelCreating(builder);
    }
}
