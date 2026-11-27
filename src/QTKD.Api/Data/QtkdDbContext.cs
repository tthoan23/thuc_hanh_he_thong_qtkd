using Microsoft.EntityFrameworkCore;
using QTKD.Api.Entities;

namespace QTKD.Api.Data;

public sealed class QtkdDbContext(DbContextOptions<QtkdDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<PriceList> PriceLists => Set<PriceList>();
    public DbSet<PriceItem> PriceItems => Set<PriceItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var customers = modelBuilder.Entity<Customer>();
        customers.Property(customer => customer.Id).HasIdentityOptions(startValue: 100);
        customers.Property(customer => customer.Status).HasConversion<string>();

        var contracts = modelBuilder.Entity<Contract>();
        contracts.Property(contract => contract.Id).HasIdentityOptions(startValue: 100);
        contracts.Property(contract => contract.Status).HasConversion<string>();
        contracts.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(contract => contract.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        var priceLists = modelBuilder.Entity<PriceList>();
        priceLists.Property(priceList => priceList.Id).HasIdentityOptions(startValue: 100);

        var priceItems = modelBuilder.Entity<PriceItem>();
        priceItems.HasKey(item => new { item.PriceListId, item.ServiceCode });
        priceItems.Property(item => item.UnitPrice).HasPrecision(18, 2);
        priceItems.HasOne<PriceList>()
            .WithMany()
            .HasForeignKey(item => item.PriceListId)
            .OnDelete(DeleteBehavior.Restrict);

        customers.HasData(
            new Customer { Id = 1, Name = "Công ty An Bình", Status = CustomerStatus.Active },
            new Customer { Id = 2, Name = "Công ty Đại Dương", Status = CustomerStatus.Inactive });

        contracts.HasData(new Contract
        {
            Id = 1,
            ContractNo = "HD-2026-017",
            CustomerId = 1,
            StartDate = new DateOnly(2026, 12, 1),
            Status = ContractStatus.Draft
        });

        priceLists.HasData(new PriceList
        {
            Id = 1,
            Name = "Bảng giá dịch vụ 2026",
            EffectiveDate = new DateOnly(2026, 11, 1)
        });

        priceItems.HasData(
            new PriceItem { PriceListId = 1, ServiceCode = "DV01", UnitPrice = 250_000m },
            new PriceItem { PriceListId = 1, ServiceCode = "DV02", UnitPrice = 450_000m });
    }
}
