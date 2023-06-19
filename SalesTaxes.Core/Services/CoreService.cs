namespace SalesTaxes.Core.Services
{
    /// <summary>
    /// Core service, main class, receives the input information and work as a controller to delegate the tasks
    /// </summary>
    public class CoreService
    {
        /// <summary>
        /// Main method called to run all steps
        /// </summary>
        /// <param name="input"></param>
        public static void Run(string[] input)
        {
            // Calling the SalesService class to get all the sales
            var sales = SaleService.Get(input);

            // Calling ReceiptService to print the receipt
            ReceiptService.PrintSalesReceipts(sales);
        }

        /// <summary>
        /// Method to check if the row entered was valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True or False for the input</returns>
        public static bool ValidateString(string input)
        {
            var price = 0.0m;
            bool isPriceValid;
            bool isQuantityValid;
            bool isNameValid;
            
            try
            {
                var priceStr = input.Remove(0, input.Length - 5);

                isPriceValid = (char.IsDigit(priceStr, 0) || priceStr[0] == ' ') &&
                                char.IsDigit(priceStr, 1) &&
                                char.IsDigit(priceStr, 3) &&
                                char.IsDigit(priceStr, 4) &&
                                priceStr[2] == '.' || false &&
                                decimal.TryParse(input.Remove(0, input.Length - 5), out price);

                isQuantityValid = _ = int.TryParse(input.Split(' ')[0], out int quantity);
                isNameValid = !string.IsNullOrEmpty(input.Split(string.Concat(" at ", price.ToString()))[0].Split(string.Concat(quantity, " "))[1]);

            }
            catch
            {
                return false;
            }

            return isPriceValid && isQuantityValid && isNameValid;
        }
    }

}
