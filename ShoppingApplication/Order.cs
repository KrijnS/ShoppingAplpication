using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Order
    {
        int orderID;
        Address address;
        PaymentMethod paymentMethod;

        public Order(int orderID, Address address, PaymentMethod paymentMethod)
        {
            this.orderID = orderID;
            this.address = address;
            this.paymentMethod = paymentMethod;
        }
    }
}
