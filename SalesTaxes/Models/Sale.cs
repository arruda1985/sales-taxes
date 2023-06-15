namespace SalesTaxes.Models
{
    /// <summary>
    /// Sale model
    /// </summary>
    public class Sale
    {
        public int Quantity { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }

        public Sale()
        {
            
        }


    }
}