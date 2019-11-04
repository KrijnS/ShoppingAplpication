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

        //Transport method, since the two differ there is no implementation in the superclass
        public abstract string TransportMethod();

        //Calculates total price of an order
        public int TotalPrice(OrderType orderType)
        {
            ShippingFee shippingFee = new ShippingFee();
            int totalPrice;
            totalPrice = this.productPrice + shippingFee.CalculateFee(this.weight, orderType);
            return totalPrice;
        }

        //Checks to see if the payment was successfull
        public string VerifyPayment()
        {
            Console.WriteLine("Payment initiated...\nWas payment succesfull? [Y|N]");
            ResponseHandler responseHandler = new ResponseHandler();
            if (responseHandler.ParseYesNo())
            {
                return "\nPayment was succesfull!";
            }
            else
            {
                Console.WriteLine("\nPayment was not succesfull, try again");
                return VerifyPayment();
            }
        }

        //Method to parse a product from string 
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

    }
}
