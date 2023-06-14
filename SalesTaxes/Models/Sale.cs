namespace SalesTaxes.Models
{
    public class Sale
    {
        public int Quantity { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }

        public Sale()
        {
            
        }

        public Sale(string input)
        {
            GetQuantity(input);
            GetProductName(input);
            GetProductPrice(input);
        }

        private void GetProductPrice(string input)
        {
            _ = decimal.TryParse(input.Remove(0, input.Length - 5), out decimal price);

            Price = price;
        }

        private void GetProductName(string input)
        {
            if (input[input.Length - 5] == ' ')
                Product = input.Remove(input.Length - 8, 8).Substring(2);
            else
                Product = input.Remove(input.Length - 9, 9).Substring(2);
        }

        private void GetQuantity(string input)
        {
            _ = int.TryParse(input.Split(' ')[0], out int quantity);

            Quantity = quantity;
        }
    }
}