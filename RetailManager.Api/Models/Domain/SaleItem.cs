namespace RetailManager.Api.Models.Domain;

public class SaleItem
{
    public Guid Id { get; set; }
    public required Guid SaleId { get; set; }
    public required Guid ItemId { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }

    // Navigation properties
    public required Sale Sale { get; set; }
    public required Item Item { get; set; }
}