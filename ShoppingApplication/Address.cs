using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Addresss
    {
        string street;
        string zipCode;
        string city;
        string houseNumber;

        public Addresss(string street, string zipCode, string city, string houseNumber)
        {
            this.street = street;
            this.zipCode = zipCode;
            this.city = city;
            this.houseNumber = houseNumber;
        }

        public Addresss GetAddress()
        {
            Addresss addresss = new Addresss(GetStreet(), GetZipCode(), GetCity(), GetHouseNumber());
            return addresss;
        }

        private string GetStreet()
        {
            Console.WriteLine("Please input street name");
            string street = Console.ReadLine();
            return street;         
        }

        private string GetZipCode()
        {
            Console.WriteLine("Please input zip code");
            string zipCode = Console.ReadLine();
            return zipCode;
        }

        private string GetCity()
        {
            Console.WriteLine("Please input city");
            string city = Console.ReadLine();
            return city;
        }

        private string GetHouseNumber()
        {
            Console.WriteLine("Please input house number and possibly addition");
            string houseNumber = Console.ReadLine();
            return houseNumber;
        }
    }
}
