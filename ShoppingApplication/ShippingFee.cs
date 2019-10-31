using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class ShippingFee
    {
        public int CalculateFee(int weight, OrderType orderType)
        {
            float fee;
            if (orderType.Equals("Inland"))
            {
                fee = 2;
            }
            else
            {
                fee = 5;
            }
            fee = fee * (weight / 100);
            return (int) fee;
        }
    }
}
