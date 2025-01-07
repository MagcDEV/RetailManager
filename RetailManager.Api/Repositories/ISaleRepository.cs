using RetailManager.Api.Models.Domain;

namespace RetailManager.Api.Repositories;

public interface ISaleRepository
{
    Task<IEnumerable<Sale>> GetAllSalesAsync();
    Task<Sale?> GetSaleByIdAsync(Guid id);
    Task<Sale> CreateSaleAsync(Sale sale);
    Task<Sale> UpdateSaleAsync(Guid id, Sale sale);
    Task<Sale> DeleteSaleAsync(Guid id);
    
}