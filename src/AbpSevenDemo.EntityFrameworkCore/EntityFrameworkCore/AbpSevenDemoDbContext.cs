using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace AbpSevenDemo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AbpSevenDemoDbContext : AbpSevenDemoDbContextBase<AbpSevenDemoDbContext>
{
    public AbpSevenDemoDbContext(DbContextOptions<AbpSevenDemoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetMultiTenancySide(MultiTenancySides.Both);

        base.OnModelCreating(builder);
    }
}
