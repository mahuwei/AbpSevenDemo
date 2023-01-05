using AbpSevenDemo.Customers;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace AbpSevenDemo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AbpSevenDemoTenantDbContext : AbpSevenDemoDbContextBase<AbpSevenDemoTenantDbContext>
{
    public DbSet<Customer> Customers { get; set; }
    public AbpSevenDemoTenantDbContext(DbContextOptions<AbpSevenDemoTenantDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetMultiTenancySide(MultiTenancySides.Tenant);

        base.OnModelCreating(builder);
        builder.Entity<Customer>(b =>
    {
        b.ToTable(AbpSevenDemoConsts.DbTablePrefix + "Customers", AbpSevenDemoConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Customer.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(Customer.Name)).IsRequired().HasMaxLength(CustomerConsts.NameMaxLength);
        b.Property(x => x.MobileNumber).HasColumnName(nameof(Customer.MobileNumber)).IsRequired().HasMaxLength(CustomerConsts.MobileNumberMaxLength);
        b.Property(x => x.Email).HasColumnName(nameof(Customer.Email)).HasMaxLength(CustomerConsts.EmailMaxLength);
        b.Property(x => x.IsCompany).HasColumnName(nameof(Customer.IsCompany));
        b.Property(x => x.Address).HasColumnName(nameof(Customer.Address)).HasMaxLength(CustomerConsts.AddressMaxLength);
    });
    }
}