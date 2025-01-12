namespace RetailManager.Api.Models.Domain;

public class OfferConditionItem
{
    public Guid Id { get; set; }
    public required Guid OfferConditionId { get; set; }
    public required Guid ItemId { get; set; }
    public required int Quantity { get; set; }
    public decimal? AdditionalItemDiscountPercentage { get; set; } // Discount for additional items

    // Navigation properties
    public required OfferCondition OfferCondition { get; set; }
    public required Item Item { get; set; }
}