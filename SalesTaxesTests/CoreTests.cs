using SalesTaxes;
using Xunit;

namespace SalesTaxesTests
{
    public class CoreTests
    {

        [Fact]
        public void LoadInputIntoSales_WithAValidInput_ShouldReturnSales()
        {
            var input = new string[] {
                                        "1 Book at 12.49",
                                        "1 Music CD at 14.99",
                                        "1 Chocolate bar at 0.85"
                                    };


            var result = Core.LoadInputIntoSales(input).ToList();

            Assert.Equal("Book", result[0].Product);
            Assert.Equal(1, result[0].Quantity);
            Assert.Equal(12.49M, result[0].Price);
            Assert.Equal("Music CD", result[1].Product);
            Assert.Equal(1, result[1].Quantity);
            Assert.Equal(14.99M, result[1].Price);
            Assert.Equal("Chocolate bar", result[2].Product);
            Assert.Equal(1, result[2].Quantity);
            Assert.Equal(0.85M, result[2].Price);
        }

        [Fact]
        public void LoadInputIntoSales_WithAInValidInput_ShouldReturnEmptyArray()
        {
            var result = Core.LoadInputIntoSales(Array.Empty<string>()).ToList();

            Assert.Empty(result);
        }
    }
}
