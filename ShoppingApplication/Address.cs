using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Address
    {
        string street;
        string zipCode;
        string city;
        string houseNumber;
        public OrderType orderType;

        public Address(string street, string zipCode, string city, string houseNumber, OrderType orderType)
        {
            this.street = street;
            this.zipCode = zipCode;
            this.city = city;
            this.houseNumber = houseNumber;
            this.orderType = orderType;
        }

        public Address GetAddress()
        {
            Address addresss = new Address(GetStreet(), GetZipCode(), GetCity(), GetHouseNumber(), GetOrderType());
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
            Regex regex = new Regex("/^[1-9][0-9]{3}?(?!sa|sd|ss)[a-z]{2}$/ i");
            string zipCode = Console.ReadLine();
            if (!(regex.IsMatch(zipCode)))
            {
                return GetZipCode();
            }
            else
            {
                return zipCode;
            }
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
            Regex regex = new Regex(@"\d+\w*$");
            string houseNumber = Console.ReadLine();
            if (!(regex.IsMatch(houseNumber)))
            { 
                return GetHouseNumber();
            }
            else
            {
                return houseNumber;
            }       
        }

        private OrderType GetOrderType()
        {
            Console.WriteLine("Please input the variation of shipping, as \u0022Inland\u0022 or \u0022Abroad\u0022");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Inland":
                    return OrderType.Inland;
                case "Abroad":
                    return OrderType.Abroad;
                default:
                    return GetOrderType();
            }

        }
    }
}
