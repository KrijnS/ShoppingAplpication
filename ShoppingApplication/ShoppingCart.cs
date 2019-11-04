using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class ShoppingCart
    {
        Dictionary<Product, int> amountOfProduct;

        public ShoppingCart(Dictionary<Product, int> amountOfProduct)
        {
            this.amountOfProduct = amountOfProduct;
        }

        public void AddToCart(Product product, int amount)
        {
            if (!(this.amountOfProduct.Count == 0) && this.amountOfProduct.TryGetValue(product, out int amountStored))
            {
                this.amountOfProduct[product] = amount + amountStored;
            }
            else
            {
                this.amountOfProduct.Add(product, amount);
            }          
        }

        public void DisplayCart()
        {
            foreach(KeyValuePair<Product,int> cartProduct in amountOfProduct)
            {
                Console.WriteLine(cartProduct.Value + "x " + cartProduct.Key.name);
            }
        }
    }
}
