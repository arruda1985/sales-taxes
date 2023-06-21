using SalesTaxes.Core.Models;

namespace SalesTaxes.Core.Services
{
    /// <summary>
    /// Tax Service
    /// </summary>
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

            if (!IsTaxFree(sale))
                totalTax += sale.Price * 0.1M;

            if (sale.Product.ToLower().Contains("imported"))
                totalTax += sale.Price * 0.05M;

            // This next row is to return the tax value rounded
            // Multiplied the number by 20 to shift the decimal point two places to the right to allow working with whole numbers.
            // Used  Math.Ceiling() method to round the number up to the nearest whole number.
            // Divided the rounded number by 20 to shift the decimal point back to its original position.
            return Math.Ceiling(totalTax * 20) / 20;
        }

        private static bool IsTaxFree(Sale sale)
        {
            return sale.ProductType == Enum.ProductTypeEnum.Food ||
                  sale.ProductType == Enum.ProductTypeEnum.Books ||
                  sale.ProductType == Enum.ProductTypeEnum.Medical;
        }
    }
}
