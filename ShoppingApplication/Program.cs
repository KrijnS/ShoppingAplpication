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
            PhysicalProduct product = new PhysicalProduct("Laptop", 300, 10, "Mooi ding");
            DigitalProduct product2 = new DigitalProduct("Software", 50, 0, "Mooi software");

            Dictionary<Product, int> amountOfProduct = new Dictionary<Product, int>();
            ShoppingCart shoppingCart = new ShoppingCart(amountOfProduct);
            shoppingCart.AddToCart(product,10);
            shoppingCart.AddToCart(product2,5);
            shoppingCart.DisplayCart();

            CustomerInterface customerInterface = new CustomerInterface();
            customerInterface.ShowAllProducts();

            System.Threading.Thread.Sleep(10000);
        }
    }
}
