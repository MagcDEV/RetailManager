namespace RetailManager.Api.Models.DTO;

public class AddItemRequest
{
   public required string Barcode { get; set; }
   public required string Description { get; set; }
   public required string ItemType { get; set; }
   public required decimal CostPrice { get; set; }
   public required decimal IvaPercentage { get; set; }
   public required decimal UtilityPercentage { get; set; }
   public required decimal SellingPrice { get; set; }
   public string? Provider { get; set; }
   public required int Stock { get; set; }
   public required int MaxStock { get; set; }
   public required int MinStock { get; set; }
   public required bool IsActive { get; set; }
   public required bool IsControlledByStock { get; set; }
    
}