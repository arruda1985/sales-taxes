namespace SalesTaxes
{
    public class Core
    {
        public static void Run(string[] input)
        {
            IEnumerable<Sale> sales = LoadInputIntoSales(input);
        }

        public static IEnumerable<Sale> LoadInputIntoSales(string[] input)
        {
            var sales = new List<Sale>();

            foreach (var i in input)
            {
                if (!string.IsNullOrEmpty(i))
                {
                    var sale = new Sale();

                    GetQuantity(i, sale);
                    GetProductName(i, sale);
                    GetProductPrice(i, sale);

                    sales.Add(sale);
                }
            }

            return sales;
        }

        private static void GetProductPrice(string i, Sale sale)
        {
            _ = decimal.TryParse(i.Remove(0, i.Length - 5), out decimal price);

            sale.Price = price;
        }

        private static void GetProductName(string i, Sale sale)
        {
            if (i[i.Length - 5] == ' ')
                sale.Product = i.Remove(i.Length - 8, 8).Substring(2);
            else
                sale.Product = i.Remove(i.Length - 9, 9).Substring(2);
        }

        private static void GetQuantity(string i, Sale sale)
        {
            _ = int.TryParse(i.Split(' ')[0], out int quantity);

            sale.Quantity = quantity;
        }
    }
}
