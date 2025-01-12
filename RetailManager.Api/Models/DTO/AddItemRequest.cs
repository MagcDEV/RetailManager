using System.ComponentModel.DataAnnotations;

namespace RetailManager.Api.Models.DTO;

public class AddItemRequest
{
   [Required]
   public required string Barcode { get; set; }
   
   [Required]
   [MaxLength(40)]
   public required string Description { get; set; }
   
   [Required]
   public required string ItemType { get; set; }
   
   [Required]
   public required decimal CostPrice { get; set; }
   public required decimal IvaPercentage { get; set; }
   public required decimal UtilityPercentage { get; set; }
   
   [Required]
   public required decimal SellingPrice { get; set; }
   
   public string? Provider { get; set; }
   public required int Stock { get; set; }
   public required int MaxStock { get; set; }
   public required int MinStock { get; set; }
   public required bool IsActive { get; set; }
   public required bool IsControlledByStock { get; set; }
    
}