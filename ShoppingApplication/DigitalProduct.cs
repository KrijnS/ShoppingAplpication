using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class DigitalProduct : Product
    {
        public DigitalProduct(string name, int productPrice, int weight) : base(name, productPrice, weight)
        {
        }

        public override string TransportMethod()
        {
            throw new NotImplementedException();
        }
    }
}
