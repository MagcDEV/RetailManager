using Microsoft.EntityFrameworkCore;
using RetailManager.Api.Data;
using RetailManager.Api.Models.Domain;

namespace RetailManager.Api.Repositories;

public class ItemRepository(RetailManagerDbContext retailManagerDbContext) : IItemRepository
{
    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await retailManagerDbContext.Items.ToListAsync(); 
    }

    public async Task<Item?> GetItemByIdAsync(Guid id)
    {
        return await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Item?> GetItemByBarcodeAsync(string barcode)
    {
        return await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Barcode == barcode);
    }

    public async Task<Item?> IncreaseStockAsync(string barcode, int quantity)
    {
        var item = await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Barcode == barcode);
        
        if (item == null)
        {
            throw new Exception("Item not found");
        }
        
        item.Stock += quantity;
        
        await retailManagerDbContext.SaveChangesAsync();

        return item;

    }

    public async Task<Item?> DecreaseStockAsync(string barcode, int quantity)
    {
        var item = await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Barcode == barcode);
        
        if (item == null)
        {
            throw new Exception("Item not found");
        }
        
        if (item.Stock < quantity)
        {
            throw new Exception("Not enough stock");
        }
        
        item.Stock -= quantity;
        
        await retailManagerDbContext.SaveChangesAsync();

        return item;
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        item.Id = Guid.NewGuid();
        item.CreatedAt = DateTime.Now;
        await retailManagerDbContext.Items.AddAsync(item);
        await retailManagerDbContext.SaveChangesAsync();
        return item;
    }

    public async Task<Item> UpdateItemAsync(Guid id, Item item)
    {
        var existingItem = await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (existingItem == null)
        {
            throw new Exception("Item not found");
        }

        existingItem.Barcode = item.Barcode;
        existingItem.Description = item.Description;
        existingItem.SellingPrice = item.SellingPrice;
        existingItem.CostPrice = item.CostPrice;
        existingItem.Stock = item.Stock;
        existingItem.Provider = item.Provider;
        existingItem.ItemType = item.ItemType;
        existingItem.MaxStock = item.MaxStock;
        existingItem.MinStock = item.MinStock;
        existingItem.UtilityPercentage = item.UtilityPercentage;
        existingItem.IvaPercentage = item.IvaPercentage;
        existingItem.IsActive = item.IsActive;
        existingItem.IsControlledByStock = item.IsControlledByStock;
        existingItem.CreatedAt = DateTime.Now;

        await retailManagerDbContext.SaveChangesAsync();
        return existingItem;
    }

    public async Task<Item> DeleteItemAsync(Guid id)
    {
        var existingItem = await retailManagerDbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (existingItem == null)
        {
            throw new Exception("Item not found");
        }

        retailManagerDbContext.Items.Remove(existingItem);
        await retailManagerDbContext.SaveChangesAsync();
        return existingItem;
    }
}