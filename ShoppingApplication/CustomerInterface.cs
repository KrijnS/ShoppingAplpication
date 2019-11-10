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
        ResponseHandler responseHandler = new ResponseHandler();
        ShoppingCart shoppingCart= new ShoppingCart(null);
        Order order = new Order(0, new Address("", "", "", "", OrderType.Inland), new ContactDetails("",null), PaymentMethod.CreditCard);
            
        public void InitShoppingCart()
        {
            shoppingCart = shoppingCart.GetShoppingCart();
        }

        //Displays catalogue of all products on screen
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

            ShowProduct(responseHandler.ReadNumberInput());
        }

        //Displays specifics about a product after selection on screen
        public void ShowProduct(int input)
        {
            if(input > allProducts.Length)
            {
                Console.WriteLine("Please input an existing product");
                ShowProduct(responseHandler.ReadNumberInput());
                return;
            }
            Product product = allProducts[input-1];
            if(product is PhysicalProduct)
            {
                Console.WriteLine("\n" + product.name + "\n" + product.productPrice + " euros " + product.weight + " grams\n" + product.description +
               "\n\nHow much of this product would you like?\n\nIf you would like to view another product please press any other key than a number");
            }
            else
            {
                Console.WriteLine("\n" + product.name + "\n" + product.productPrice + " euros\n" + product.description +
              "\n\nHow much of this product would you like?\n\nIf you would like to view another product please press any other key than a number");
            }
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                shoppingCart.AddToCart(input-1,amount);
                shoppingCart.DisplayCart();
                Console.WriteLine("\nDo you want to finalize your order? [Y|N]");
                if (responseHandler.ParseYesNo())
                {
                    order.CompleteOrder(shoppingCart);
                }
                else
                {
                    ShowAllProducts();
                }
            }
            else
            {
                ShowAllProducts();
            }
        }

    }
}
