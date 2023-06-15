using SalesTaxes;

// Same inputs from test
var input3 = new string[] {
                                        "1 Imported bottle of perfume at 27.99",
                                        "1 Bottle of perfume at 18.99",
                                        "1 Packet of headache pills at 9.75",
                                        "1 Imported box of chocolates at 11.25",
                                        "1 Imported box of chocolates at 11.25"
                                     };

var input2 = new string[] {
                                       "1 Imported box of chocolates at 10.00",
                                       "1 Imported bottle of perfume at 47.50"
                                     };

var input1 = new string[] {
                                        "1 Book at 12.49",
                                        "1 Book at 12.49",
                                        "1 Music CD at 14.99",
                                        "1 Chocolate bar at 0.85"
                                    };



// Calling the process for each input
Core.Run(input1);
Console.WriteLine("================================");

Core.Run(input2);
Console.WriteLine("================================");

Core.Run(input3);