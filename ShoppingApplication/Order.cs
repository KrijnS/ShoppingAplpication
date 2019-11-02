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
        UIOrder uIOrder;

        public Order(int orderID, Address address, UIOrder uIOrder)
        {
            this.orderID = orderID;
            this.address = address;
            this.uIOrder = uIOrder;
        }
    }
}
