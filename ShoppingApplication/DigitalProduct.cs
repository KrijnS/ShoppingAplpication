using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class DigitalProduct : Product
    {
        public DigitalProduct(string name, int productPrice, int weight) : base(name, productPrice, weight)
        {
        }

        public override string TransportMethod()
        {
            return "Your product is ready for download: " + this.name + ".nl/download \nUse product key: " + GenerateKey();
        }

        public string GenerateKey()
        {
            Random rand = new Random();
            char[] productKey = new char[16];
            for(int i = 0; i < 16; i++)
            {
                int randomAscii = rand.Next(48, 83);
                if(randomAscii > 57)
                {
                    randomAscii += 8;
                }
                productKey[i] = Convert.ToChar(randomAscii);
            }

            string tempKey = new string(productKey);
            string key = tempKey.Insert(4, "-");
            tempKey = key.Insert(9, "-");
            key = tempKey.Insert(14, "-");
            return key;
        }
    }
}
