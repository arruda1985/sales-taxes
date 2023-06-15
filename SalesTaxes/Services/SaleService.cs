using SalesTaxes.Models;

namespace SalesTaxes.Services
{
    public class SaleService
    {
        /// <summary>
        /// Get the sales from the input
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns>List of sales</returns>
        public static IEnumerable<Sale> Get(string[] inputArray)
        {
            var sales = new List<Sale>();

            foreach (var input in inputArray)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    var sale = new Sale();

                    GetQuantity(input, sale);
                    GetProductName(input, sale);
                    GetProductPrice(input, sale);
                    sales.Add(sale);
                }
            }

            return sales;
        }

        private static void GetProductPrice(string input, Sale sale)
        {
            _ = decimal.TryParse(input.Remove(0, input.Length - 5), out decimal price);

            sale.Price = price;
        }

        private static void GetProductName(string input, Sale sale)
        {
            if (input[input.Length - 5] == ' ')
                sale.Product = input.Remove(input.Length - 8, 8).Substring(2);
            else
                sale.Product = input.Remove(input.Length - 9, 9).Substring(2);
        }

        private static void GetQuantity(string input, Sale sale)
        {
            _ = int.TryParse(input.Split(' ')[0], out int quantity);

            sale.Quantity = quantity;
        }
    }
}
