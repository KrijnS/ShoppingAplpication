using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Parser
    {
        Product[] allProducts;

        //Method to read all products from file and return them in an array
        public Product[] GetProducts()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            PhysicalProduct product = new PhysicalProduct("",10,10,"");
            allProducts = new Product[allLines.Length];
            for(int i = 0; i < allLines.Length; i++)
            {
                allProducts[i] = product.ParseProduct(allLines[i]);
            }

            return allProducts;
        }
    }
}
