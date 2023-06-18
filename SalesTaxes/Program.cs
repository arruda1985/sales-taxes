using SalesTaxes.Core.Services;

var inputStr = new List<string>();
Console.WriteLine("Please enter row by row of the sale");
Console.WriteLine("");
Console.WriteLine("Valid format '[quantity] [nameOfTheProduct] at [price]'");
Console.WriteLine("");
Console.WriteLine("");
while (true)
{
    Console.WriteLine("Enter a valid sale row, [Type 'print' to print the receipt]");
    var aux = Console.ReadLine();

    if (aux.ToLower() != "print")
    {
        if (ValidateString(aux))
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

Console.Clear();

Console.WriteLine("----------Receipt----------");
Console.WriteLine("");
Console.WriteLine("");
CoreService.Run(inputStr.ToArray());

bool ValidateString(string input)
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

