using SalesTaxes.Models;

namespace SalesTaxes
{
    public class Core
    {
        public static void Run(string[] input)
        {
            IEnumerable<Sale> sales = LoadInputIntoSales(input);


        }

        public static IEnumerable<Sale> LoadInputIntoSales(string[] inputArray)
        {
            var sales = new List<Sale>();

            foreach (var input in inputArray)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    sales.Add(new Sale(input));
                }
            }

            return sales;
        }


    }
}
