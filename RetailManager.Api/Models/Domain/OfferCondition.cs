namespace RetailManager.Api.Models.Domain;

public class OfferCondition
{
    public Guid Id { get; set; }
    public required Guid OfferId { get; set; }
    public required List<OfferConditionItem> ConditionItems { get; set; } = new();

    // Navigation properties
    public required Offer Offer { get; set; }
}