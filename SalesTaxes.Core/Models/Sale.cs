using SalesTaxes.Core.Enum;

namespace SalesTaxes.Core.Models
{
    /// <summary>
    /// Sale model
    /// </summary>
    public class Sale
    {
        public int Quantity { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }
        public bool Imported { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}