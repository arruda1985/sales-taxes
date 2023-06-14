using SalesTaxes.Constants;
using SalesTaxes.Models;
using System.Data.SqlTypes;

namespace SalesTaxes
{
    public class Core
    {
        public static void Run(string[] input)
        {
            IEnumerable<Sale> sales = LoadInputIntoSales(input);

            PrintSalesReceipts(sales);
        }

        private static void PrintSalesReceipts(IEnumerable<Sale> sales)
        {
            var taxes = "";
            var total = "";

            var productPrinted = new List<string>();

            foreach (var sale in sales)
            {
                if (productPrinted.Contains(sale.Product))
                    continue;

                var salesFound = sales.Where(s => s.Product == sale.Product);

                var saleTaxe = GetSaleTax(sale);

                var lnToPrint = $"{sale.Product}: {salesFound.Sum(s => s.Price)} ";

                if (salesFound.Count() > 1)
                    lnToPrint += $"({salesFound.Count()} @ {sale.Price})";

                productPrinted.Add(sale.Product);
                Console.WriteLine(lnToPrint);
            }

            Console.WriteLine($"Sales Taxes: {taxes}");
            Console.WriteLine($"Total: {total}");
        }

        public static decimal GetSaleTax(Sale sale)
        {
            throw new NotImplementedException();
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
