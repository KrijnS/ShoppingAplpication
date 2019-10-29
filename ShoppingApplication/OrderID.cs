using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class OrderID
    {
        public int generateID()
        {
            Random rand = new Random();
            int id = rand.Next(2147483647);
            return id;
        }
    }
}
