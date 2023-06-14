using SalesTaxes;
using Xunit;

namespace SalesTaxesTests
{
    public class CasesTests
    {
        private readonly StringWriter _stringWriter;

        public CasesTests()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [Fact]
        public void Case3()
        {

            var input = new string[] {
                                        "1 Imported bottle of perfume at 27.99",
                                        "1 Bottle of perfume at 18.99",
                                        "1 Packet of headache pills at 9.75",
                                        "1 Imported box of chocolates at 11.25",
                                        "1 Imported box of chocolates at 11.25"
                                     };

            Core.Run(input);

            var output = _stringWriter.ToString().Split("\r\n");

            Assert.Equal("Book: 24.98 (2 @ 12.49)", output[0]);
            Assert.Equal("Music CD: 16.49", output[1]);
            Assert.Equal("Chocolate bar: 0.85", output[2]);
            Assert.Equal("Sales Taxes: 1.50", output[3]);
            Assert.Equal("Total: 42.32", output[4]);
        }

        [Fact]
        public void Case2()
        {

            var input = new string[] {
                                       "1 Imported box of chocolates at 10.00",
                                       "1 Imported bottle of perfume at 47.50"
                                     };
            Core.Run(input);

            var output = _stringWriter.ToString().Split("\r\n");


            Assert.Equal("Imported box of chocolates: 10.50", output[0]);
            Assert.Equal("Imported bottle of perfume: 54.65", output[1]);
            Assert.Equal("Sales Taxes: 7.65", output[2]);
            Assert.Equal("Total: 65.15", output[3]);
        }

        [Fact]
        public void Case1()
        {

            var input = new string[] {
                                        "1 Book at 12.49",
                                        "1 Book at 12.49",
                                        "1 Music CD at 14.99",
                                        "1 Chocolate bar at 0.85"
                                    };

            Core.Run(input);

            var output = _stringWriter.ToString().Split("\r\n");


            Assert.Equal("Imported bottle of perfume: 32.19", output[0]);
            Assert.Equal("Bottle of perfume: 20.89", output[1]);
            Assert.Equal("Packet of headache pills: 9.75", output[2]);
            Assert.Equal("Imported box of chocolates: 23.70 (2 @ 11.85)", output[3]);
            Assert.Equal("Sales Taxes: 7.30", output[4]);
            Assert.Equal("Total: 86.53", output[5]);
        }
    }
}
