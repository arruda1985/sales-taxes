
using SalesTaxes.Core.Models;

namespace SalesTaxes.Core.Services
{
    /// <summary>
    /// Sale service
    /// </summary>
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
                    GetProductPrice(input, sale);
                    GetProductName(input, sale);
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
            sale.Product = input.Split(string.Concat(" at ", sale.Price.ToString()))[0].Split(string.Concat(sale.Quantity, " "))[1];
        }

        private static void GetQuantity(string input, Sale sale)
        {
            _ = int.TryParse(input.Split(' ')[0], out int quantity);

            sale.Quantity = quantity;
        }

    }
}
