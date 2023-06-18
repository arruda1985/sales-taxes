using Bogus;
using SalesTaxes.Core.Constants;
using SalesTaxes.Core.Models;
using SalesTaxes.Core.Services;
using Xunit;

namespace SalesTaxesTests.Services
{
    public class TaxServiceTests
    {
        [Fact]
        public void GetSaleTax_WithImportedDiscount_ReturnsImportTax()
        {
            var faker = new Faker<Sale>();

            faker.RuleFor(r => r.Product, () => "Imported bottle of perfume")
                 .RuleFor(r => r.Price, () => 47.50M);

            var sale = faker.Generate(1).First();

            var tax = TaxService.GetSaleTax(sale);


            Assert.Equal(7.15M, tax);
        }

        [Fact]
        public void GetSaleTax_WithoutDiscount_ReturnsTax()
        {
            var faker = new Faker<Sale>();

            faker.RuleFor(r => r.Product, () => "Music CD")
                 .RuleFor(r => r.Price, () => 14.99M);

            var sale = faker.Generate(1).First();

            var tax = TaxService.GetSaleTax(sale);

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

            var tax = TaxService.GetSaleTax(sale);

            Assert.Equal(0, tax);
        }
    }
}
