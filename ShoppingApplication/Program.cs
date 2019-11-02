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


            //DigitalProduct digital = new DigitalProduct("productX", 10, 10, "Goed product");
            //Console.WriteLine(digital.TransportMethod());

            Parser parser = new Parser();
            Product[] allProducts = parser.GetProducts();
            for(int i = 0; i < allProducts.Length; i++)
            {
                if(allProducts[i] is DigitalProduct)
                {
                    Console.WriteLine("Does not need shipping");
                }
                else
                {
                    Console.WriteLine("Does need shipping");
                }
            }
            System.Threading.Thread.Sleep(5000);
        }
    }
}
