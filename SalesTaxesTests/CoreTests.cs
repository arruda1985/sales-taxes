using Bogus;
using SalesTaxes;
using SalesTaxes.Constants;
using SalesTaxes.Models;
using Xunit;

namespace SalesTaxesTests
{
    public class CoreTests
    {
      
        [Fact]
        public void GetSaleTax_WithImportedDiscount_ReturnsImportTax()
        {
            var faker = new Faker<Sale>();

            faker.RuleFor(r => r.Product, () => "Imported bottle of perfume")
                 .RuleFor(r => r.Price, () => 47.50M);

            var sale = faker.Generate(1).First();

            var tax = Core.GetSaleTax(sale);


            Assert.Equal(28.50M, tax); 
        }

        [Fact]
        public void GetSaleTax_WithoutDiscount_ReturnsTax()
        {
            var faker = new Faker<Sale>();

            faker.RuleFor(r => r.Product, () => "Music CD")
                 .RuleFor(r => r.Price, () => 14.99M);

            var sale = faker.Generate(1).First();

            var tax = Core.GetSaleTax(sale);

            Assert.Equal(1.50M, tax);
        }

        [Fact]
        public void GetSaleTax_WithExceptionDiscount_ReturnsZero()
        {
            var faker = new Faker();
            var saleFaker = new Faker<Sale>();

            saleFaker.RuleFor(r => r.Product, () => ProductsGroupingTaxes.TaxExceptions[0])
                     .RuleFor(r => r.Price, () => faker.Random.Decimal(1, 99));

            var sale = saleFaker.Generate(1).First();

            var tax = Core.GetSaleTax(sale);

            Assert.Equal(0, tax);
        }

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
