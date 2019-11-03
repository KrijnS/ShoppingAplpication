using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Address addresss = new Address(null, null, null, null, OrderType.Inland);
            //Address add = addresss.GetAddress();


            // digital = new DigitalProduct("productX", 10, 10, "Goed product");
            //Console.WriteLine(digital.TransportMethod());

            CustomerInterface customerInterface = new CustomerInterface();
            customerInterface.ShowAllProducts();

            customerInterface.ShowProduct((customerInterface.ReadInput()));
            System.Threading.Thread.Sleep(10000);
        }
    }
}
