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

            
            DigitalProduct digital = new DigitalProduct("productX", 10, 10);
            Console.WriteLine(digital.TransportMethod());
            System.Threading.Thread.Sleep(5000);
        }
    }
}
