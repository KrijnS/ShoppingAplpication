using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class CustomerInterface
    {
        Parser parser = new Parser();
        Product[] allProducts;

        public void ShowAllProducts()
        {
            allProducts = parser.GetProducts();
            for(int i = 0; i < allProducts.Length; i++)
            {
                if(i == 0)
                {
                    Console.WriteLine("Select a product");
                }
                int index = i + 1;
                Console.WriteLine("[" + index + "] " + allProducts[i].name);
            }

            ShowProduct(ReadInput());
        }

        public int ReadInput()
        {
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch
            {
                Console.WriteLine("Please input a number");
                return ReadInput();
            }
            
        }

        public void ShowProduct(int input)
        {
            if(input > allProducts.Length)
            {
                Console.WriteLine("Please input an existing product");
                ShowProduct(ReadInput());
                return;
            }
            Product product = allProducts[input-1];
            if(product is PhysicalProduct)
            {
                Console.WriteLine(product.name + "\n" + product.productPrice + " euros " + product.weight + " grams\n" + product.description +
               "\nHow much of this product would you like?\n\nIf you would like to view another product please press any other key than a number");
            }
            else
            {
                Console.WriteLine(product.name + "\n" + product.productPrice + " euros\n" + product.description +
              "\nHow much of this product would you like?\n\nIf you would like to view another product please press any other key than a number");
            }
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                product.AddToCart(amount);
            }
            else
            {
                ShowAllProducts();
            }
        }

    }
}
