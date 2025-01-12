namespace RetailManager.Api.Models.Domain;

public class Offer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public decimal? DiscountAmount { get; set; }
    public required bool IsPercentage { get; set; }
    public required List<OfferCondition> Conditions { get; set; } = new();
    
    // Navigation property for related sales
    public required List<Sale> Sales { get; set; } = new();
}