using SalesTaxes.Constants;
using SalesTaxes.Models;

namespace SalesTaxes.Services
{
    public class TaxService
    {
        /// <summary>
        /// Calculates the tax
        /// </summary>
        /// <param name="sale"></param>
        /// <returns>Tax for the sale</returns>
        public static decimal GetSaleTax(Sale sale)
        {
            var totalTax = 0.0M;

            if (!ProductsGroupingTaxes.TaxExceptions.Contains(sale.Product))
                totalTax += sale.Price * 0.1M;

            if (sale.Product.Contains("Imported"))
                totalTax += sale.Price * 0.05M;

            return Math.Ceiling(totalTax * 20) / 20;
        }
    }
}
