using RetailManager.Api.Models.Domain;

namespace RetailManager.Api.Repositories;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item?> GetItemByIdAsync(Guid id);
    Task<Item?> GetItemByBarcodeAsync(string barcode);
    
    Task<Item?> IncreaseStockAsync(string barcode, int quantity);
    Task<Item?> DecreaseStockAsync(string barcode, int quantity);
    Task<Item> CreateItemAsync(Item item);
    Task<Item> UpdateItemAsync(Guid id, Item item);
    Task<Item> DeleteItemAsync(Guid id);
}