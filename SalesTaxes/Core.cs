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
            var taxesTotal = 00.00M;
            var total = 00.00M;

            var productsPrinted = new List<string>();

            foreach (var sale in sales)
            {
                if (productsPrinted.Contains(sale.Product))
                    continue;



                var salesFound = sales.Where(s => s.Product == sale.Product);

                var totalQuantity = salesFound.Sum(s => s.Quantity);

                var saleTaxe = GetSaleTax(sale);

                var priceWithTax = sale.Price + saleTaxe;

                total += priceWithTax * totalQuantity;
                taxesTotal += saleTaxe * totalQuantity;

                var lnToPrint = $"{sale.Product}: {priceWithTax * totalQuantity}";

                if (salesFound.Count() > 1)
                    lnToPrint += $" ({totalQuantity} @ {sale.Price + saleTaxe})";

                productsPrinted.Add(sale.Product);
                Console.WriteLine(lnToPrint);
            }

            Console.WriteLine($"Sales Taxes: {taxesTotal}");
            Console.WriteLine($"Total: {total}");
        }

        public static decimal GetSaleTax(Sale sale)
        {
            var totalTax = 0.0M;


            if (!ProductsGroupingTaxes.TaxExceptions.Contains(sale.Product))
                totalTax += sale.Price * 0.1M;

            if (sale.Product.Contains("Imported"))
                totalTax += sale.Price * 0.05M;


            return Math.Ceiling(totalTax * 20) / 20;
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
