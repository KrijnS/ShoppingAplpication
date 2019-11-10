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
        public int[] amountOfProduct;

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
            if(amountOfProduct[index] + amount < 0)
            {
                amountOfProduct[index] = 0;
            }
            else
            {
                this.amountOfProduct[index] += amount;
            }          
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

        public bool CheckForShipping()
        {
            for(int i = 0; i < this.amountOfProduct.Length; i++)
            {
                if(this.amountOfProduct[i] > 0)
                {
                    if(parser.GetProductFromIndex(i).GetType() == typeof(PhysicalProduct))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int PriceOfCart(OrderType orderType)
        {
            int totalPrice = 0;
            for (int i = 0; i < this.amountOfProduct.Length; i++)
            {
                if (this.amountOfProduct[i] > 0)
                {
                    totalPrice += this.amountOfProduct[i] * parser.GetProductFromIndex(i).TotalPrice(orderType);
                }
            }
            return totalPrice;
        }
    }
}
