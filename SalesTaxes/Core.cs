using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    public class Core
    {
        public void Run(string[] input)
        {
            IEnumerable<Sale> incommingValues = LoadInputIntoSales(input);
        }

        private IEnumerable<Sale> LoadInputIntoSales(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
