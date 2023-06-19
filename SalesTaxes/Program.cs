// Top Level statement used to load the sales input
using SalesTaxes.Core.Services;

var inputStr = new List<string>();

// writing basic instructions for the user
Console.WriteLine("Please enter row by row of the sale");
Console.WriteLine("");
Console.WriteLine("Valid format '[quantity] [nameOfTheProduct] at [price]'");
Console.WriteLine("");
Console.WriteLine("");


// loading the sales rows
while (true)
{
    Console.WriteLine("Enter a valid sale row, [Type 'print' to print the receipt]");
    var aux = Console.ReadLine();

    if (aux != null && aux.ToLower() != "print")
    {
        if (CoreService.ValidateString(aux))
        {
            inputStr.Add(aux);
        }
        else
        {
            Console.WriteLine($"Invalid entered input:{aux} -> Valid format '[quantity] [nameOfTheProduct] at [price]'");
        }
    }
    else
        break;


}

// Clearing console to print the receipt
Console.Clear();

Console.WriteLine("----------Receipt----------");
Console.WriteLine("");
Console.WriteLine("");

// Running the Core service to do all the work
CoreService.Run(inputStr.ToArray());





