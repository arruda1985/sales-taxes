namespace SalesTaxes.Core.Services
{
    /// <summary>
    /// Core Service
    /// </summary>
    public class CoreService
    {
        /// <summary>
        /// Main class, receives the input information and work as a controller to delegate the tasks
        /// </summary>
        /// <param name="input"></param>
        public static void Run(string[] input)
        {
            // Calling the SalesService class to get all the sales
            var sales = SaleService.Get(input);

            // Calling ReceiptService to print the receipt
            ReceiptService.PrintSalesReceipts(sales);
        }

        // Method to check if the row entered was valid
        public static bool ValidateString(string input)
        {
            var result = false;

            try
            {
                result = decimal.TryParse(input.Remove(0, input.Length - 5), out decimal price);
                result = _ = int.TryParse(input.Split(' ')[0], out int quantity);
                result = !string.IsNullOrEmpty(input.Split(string.Concat(" at ", price.ToString()))[0].Split(string.Concat(quantity, " "))[1]);

            }
            catch
            {
                return false;
            }

            return result;
        }
    }

}
