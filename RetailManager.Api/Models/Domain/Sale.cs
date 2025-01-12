namespace RetailManager.Api.Models.Domain;

public class Sale
{
    public Guid Id { get; set; }
    public required string InvoiceType { get; set; }
    public required DateTime SaleDateTime { get; set; }
    public string? CAE { get; set; }
    public string? ClientName { get; set; }
    public string? DNICUIT { get; set; }
    public required decimal SaleAmount { get; set; }
    
    // Navigation property for related sale items
    public required List<SaleItem> SaleItems { get; set; } = new();
    
    // Navigation property for applied offers
    public required List<Offer> AppliedOffers { get; set; } = new();
}