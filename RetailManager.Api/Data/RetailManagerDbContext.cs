using Microsoft.EntityFrameworkCore;
using RetailManager.Api.Models.Domain;

namespace RetailManager.Api.Data;

public class RetailManagerDbContext(DbContextOptions<RetailManagerDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<OfferCondition> OfferConditions { get; set; }
    public DbSet<OfferConditionItem> OfferConditionItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasKey(i => i.Id);
        modelBuilder.Entity<Item>().HasIndex(i => i.Barcode).IsUnique();
        modelBuilder.Entity<Item>().Property(i => i.CostPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Item>().Property(i => i.IvaPercentage).HasPrecision(18, 2);
        modelBuilder.Entity<Item>().Property(i => i.SellingPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Item>().Property(i => i.UtilityPercentage).HasPrecision(18, 2);

        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<Sale>().HasKey(s => s.Id);
        modelBuilder.Entity<Sale>().HasMany(s => s.SaleItems).WithOne(si => si.Sale).HasForeignKey(si => si.SaleId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Sale>().HasMany(s => s.AppliedOffers).WithMany(o => o.Sales);
        modelBuilder.Entity<Sale>().Property(s => s.SaleAmount).HasPrecision(18, 2);

        modelBuilder.Entity<SaleItem>().ToTable("SaleItems");
        modelBuilder.Entity<SaleItem>().HasKey(si => si.Id);
        modelBuilder.Entity<SaleItem>().HasOne(si => si.Item).WithMany().HasForeignKey(si => si.ItemId);
        modelBuilder.Entity<SaleItem>().Property(si => si.Price).HasPrecision(18, 2);

        modelBuilder.Entity<Offer>().ToTable("Offers");
        modelBuilder.Entity<Offer>().HasKey(o => o.Id);
        modelBuilder.Entity<Offer>().HasMany(o => o.Conditions).WithOne(oc => oc.Offer).HasForeignKey(oc => oc.OfferId);
        modelBuilder.Entity<Offer>().Property(o => o.DiscountAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Offer>().Property(o => o.DiscountPercentage).HasPrecision(18, 2);

        modelBuilder.Entity<OfferCondition>().ToTable("OfferConditions");
        modelBuilder.Entity<OfferCondition>().HasKey(oc => oc.Id);
        modelBuilder.Entity<OfferCondition>().HasMany(oc => oc.ConditionItems).WithOne(oci => oci.OfferCondition).HasForeignKey(oci => oci.OfferConditionId);

        modelBuilder.Entity<OfferConditionItem>().ToTable("OfferConditionItems");
        modelBuilder.Entity<OfferConditionItem>().HasKey(oci => oci.Id);
        modelBuilder.Entity<OfferConditionItem>().HasOne(oci => oci.Item).WithMany().HasForeignKey(oci => oci.ItemId);
        modelBuilder.Entity<OfferConditionItem>().Property(oci => oci.AdditionalItemDiscountPercentage).HasPrecision(18, 2);
    }
    
}