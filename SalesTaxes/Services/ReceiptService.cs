using SalesTaxes.Models;

namespace SalesTaxes.Services
{
    public class ReceiptService
    {
        /// <summary>
        /// Calculates taxes/total and print the receipt information
        /// </summary>
        /// <param name="sales"></param>
        public static void PrintSalesReceipts(IEnumerable<Sale> sales)
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

                // Calling the TaxService to deal with the tax logic
                var saleTaxe = TaxService.GetSaleTax(sale);

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

       

    }
}
