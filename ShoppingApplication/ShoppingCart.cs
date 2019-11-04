using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class ShoppingCart
    {
        Parser parser = new Parser();
        int[] amountOfProduct;

        public ShoppingCart(int[] amountOfProduct)
        {
            this.amountOfProduct = amountOfProduct;
        }

        public ShoppingCart GetShoppingCart()
        {
            this.amountOfProduct = new int[parser.GetAmountOfProducts()];
            ShoppingCart shoppingCart = new ShoppingCart(this.amountOfProduct);
            return shoppingCart;
        }

        public void AddToCart(int index, int amount)
        {
            this.amountOfProduct[index] += amount;
        }

        public void DisplayCart()
        {
            for(int i = 0; i < this.amountOfProduct.Length; i++)
            {
                if(this.amountOfProduct[i] > 0)
                {
                    Console.WriteLine(this.amountOfProduct[i] + "x " + parser.GetProductFromIndex(i).name);
                }
            }
        }
    }
}
