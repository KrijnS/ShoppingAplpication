using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    abstract class Product
    {
        string name;
        int productPrice;
        int weight;

        public Product(string name, int productPrice, int weight)
        {
            this.name = name;
            this.productPrice = productPrice;
            this.weight = weight;
        }

        public abstract string TransportMethod();

        public int TotalPrice(OrderType orderType)
        {
            ShippingFee shippingFee = new ShippingFee();
            int totalPrice;
            totalPrice = this.productPrice + shippingFee.CalculateFee(this.weight, orderType);
            return totalPrice;
        }
    }
}
