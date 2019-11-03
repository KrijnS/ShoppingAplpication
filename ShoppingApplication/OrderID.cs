using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class OrderID
    {
        //Generates random integer to be used as ID
        public int generateID()
        {
            Random rand = new Random();
            int id = rand.Next(2147483647);
            return id;
        }
    }
}
