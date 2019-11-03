using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class ResponseHandler
    {
        public bool ParseYesNo()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    Console.WriteLine("Please input \"Y\" or \"N\"");
                    return ParseYesNo();
            }
        }

        public int ReadNumberInput()
        {
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch
            {
                Console.WriteLine("Please input a number");
                return ReadNumberInput();
            }

        }
    }
}
