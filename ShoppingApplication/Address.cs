using System;
using System.Text.RegularExpressions;

namespace ShoppingApplication
{
    class Address
    {
        string street;
        string zipCode;
        string city;
        string houseNumber;
        public OrderType orderType;

        //Basic constructor for Address class
        public Address(string street, string zipCode, string city, string houseNumber, OrderType orderType)
        {
            this.street = street;
            this.zipCode = zipCode;
            this.city = city;
            this.houseNumber = houseNumber;
            this.orderType = orderType;
        }

        //Get the needed Address from customer
        public Address GetAddress()
        {
            Address addresss = new Address(GetStreet(), GetZipCode(), GetCity(), GetHouseNumber(), GetOrderType());
            return addresss;
        }

        //Get street from customer, needed for GetAddress()
        private string GetStreet()
        {
            Console.WriteLine("Please input street name");
            string street = Console.ReadLine();
            return street;         
        }

        //Get zip code from customer, needed for GetAddress()
        private string GetZipCode()
        {
            Console.WriteLine("Please input zip code. Use \u00221111AA\u0022");
            Regex regex = new Regex("^[1-9][0-9]{3}?[a-zA-Z]{2}$");
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

        //Get city from customer, needed for GetAddres()
        private string GetCity()
        {
            Console.WriteLine("Please input city");
            string city = Console.ReadLine();
            return city;
        }

        //Get house number from customer, needed for GetAddress(). Regex checks the input to contain a digit and possibly a char addition
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

        //Get the order type, inland or abroad, from the customer. Needed for GetAddress()
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
