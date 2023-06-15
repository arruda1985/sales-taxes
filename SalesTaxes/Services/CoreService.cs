namespace SalesTaxes.Services
{
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
    }
}
