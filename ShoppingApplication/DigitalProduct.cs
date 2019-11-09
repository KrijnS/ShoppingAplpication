using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class DigitalProduct : Product
    {
        public DigitalProduct(string name, int productPrice, int weight, string description) : base(name, productPrice, weight, description)
        {
        }

        //Specific transport method for digital products
        public override string TransportMethod()
        {
            return "Your product is ready for download: productkey.nl/download \nUse product key: " + GenerateKey();
        }

        //Generates random key of 16 chars/digits, the random number is done in Ascii to make it possible to have a digit or char come out
        public string GenerateKey()
        {

            Random rand = new Random(DateTime.Now.Millisecond);
            char[] productKey = new char[16];
            for (int i = 0; i < 16; i++)
            {
                int randomAscii = rand.Next(48, 83);
                if (randomAscii > 57)
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
