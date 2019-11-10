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

            CustomerInterface customerInterface = new CustomerInterface();
            customerInterface.InitShoppingCart();
            customerInterface.ShowAllProducts();

            System.Threading.Thread.Sleep(10000);
        }
    }
}
