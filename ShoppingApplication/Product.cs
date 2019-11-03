using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    abstract class Product
    {
        public string name;
        public int productPrice;
        public int weight;
        public string description;

        public Product(string name, int productPrice, int weight, string description)
        {
            this.name = name;
            this.productPrice = productPrice;
            this.weight = weight;
            this.description = description;
        }

        public abstract string TransportMethod();

        public int TotalPrice(OrderType orderType)
        {
            ShippingFee shippingFee = new ShippingFee();
            int totalPrice;
            totalPrice = this.productPrice + shippingFee.CalculateFee(this.weight, orderType);
            return totalPrice;
        }

        public string VerifyPayment()
        {
            Console.WriteLine("Payment initiated.../nWas payment succesfull? [Y|N]");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    return "Payment not yet implemented";
                case "N":
                    return "Payment cancelled, try again";
                default:
                    return VerifyPayment();
            }
        }

        public Product ParseProduct(string productText)
        {
            string[] productInfo = productText.Split(',');
            if (productInfo[3].Equals("Digital"))
            {
                DigitalProduct product = new DigitalProduct(productInfo[0], Convert.ToInt32(productInfo[1]), Convert.ToInt32(productInfo[2]), productInfo[4]);
                return product;
            }
            else
            {
                PhysicalProduct product = new PhysicalProduct(productInfo[0], Convert.ToInt32(productInfo[1]), Convert.ToInt32(productInfo[2]), productInfo[4]);
                return product;
            }
        }

        public void AddToCart(int amount)
        {
            Console.WriteLine(amount + "x " + this.name + " has been added to your cart");
        }
    }
}
