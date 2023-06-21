
using SalesTaxes.Core.Enum;
using SalesTaxes.Core.Models;
using System.Net.Http.Headers;

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

                    var splitted = input.Split('|');

                    GetQuantity(splitted[0], sale);
                    GetProductPrice(splitted[0], sale);
                    GetProductName(splitted[0], sale);
                    GetProductType(splitted[1], sale);
                    sales.Add(sale);
                }
            }

            return sales;
        }

        private static void GetProductType(string input, Sale sale)
        {
            switch (input)
            {
                case "1":
                    sale.ProductType = ProductTypeEnum.Food;
                    break;
                case "2":
                    sale.ProductType = ProductTypeEnum.Medical;
                    break;
                case "3":
                    sale.ProductType = ProductTypeEnum.Books;
                    break;
                default:
                    sale.ProductType = ProductTypeEnum.Others;
                    break;
            }

        }

        private static void GetProductPrice(string input, Sale sale)
        {
            var inputLength = input.Length;

            var priceStr = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    priceStr = input.Substring(i);
                    break;
                }

            }

            _ = decimal.TryParse(priceStr, out decimal price);

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
