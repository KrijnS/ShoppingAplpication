using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class PhysicalProduct : Product
    {
        public PhysicalProduct(string name, int productPrice, int weight, string description) : base(name, productPrice, weight, description)
        {
        }

        //Specific transport method for physical products
        public override string TransportMethod()

        {
            return this.name + " will be transported to your address!";
        }
    }
}
