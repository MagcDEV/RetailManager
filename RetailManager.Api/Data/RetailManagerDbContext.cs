using Microsoft.EntityFrameworkCore;
using RetailManager.Api.Models.Domain;

namespace RetailManager.Api.Data;

public class RetailManagerDbContext(DbContextOptions<RetailManagerDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasKey(i => i.Id);
        modelBuilder.Entity<Item>().HasIndex(i => i.Barcode).IsUnique();
    }
    
}