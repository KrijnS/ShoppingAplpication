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

            Dictionary<Product, int> amountOfProduct = new Dictionary<Product, int>();
            ShoppingCart shoppingCart = new ShoppingCart(amountOfProduct);
           
            CustomerInterface customerInterface = new CustomerInterface();
            customerInterface.ShowAllProducts();

            System.Threading.Thread.Sleep(10000);
        }
    }
}
