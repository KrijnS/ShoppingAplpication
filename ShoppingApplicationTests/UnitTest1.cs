using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingApplication;

namespace ShoppingApplicationTests
{
    [TestClass]
    public class UnitTest1
    {
        //Check if digital product only will have shipping fee
        [TestMethod]
        public void NoShippingForDigital()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(0, 8);
            shoppingCart.AddToCart(4, 10);
            Parser parser = new Parser();
            DigitalProduct one = (DigitalProduct) parser.GetProductFromIndex(0);
            DigitalProduct two = (DigitalProduct) parser.GetProductFromIndex(4);
            int expectedPrice = 8 * one.productPrice + 10 * two.productPrice;

            Assert.IsTrue(expectedPrice == shoppingCart.PriceOfCart(OrderType.Inland));
        }

        //Check if physical product will have shipping fee
        [TestMethod]
        public void ShippingForPhysical()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(1, 8);
            shoppingCart.AddToCart(4, 10);
            Parser parser = new Parser();
            PhysicalProduct one = (PhysicalProduct)parser.GetProductFromIndex(1);
            DigitalProduct two = (DigitalProduct)parser.GetProductFromIndex(4);
            int noShippingPrice = 8 * one.productPrice + 10 * two.productPrice;

            Assert.IsTrue(noShippingPrice < shoppingCart.PriceOfCart(OrderType.Inland));
        }

        //Check if shopping cart has a zero quantity in the order
        [TestMethod]
        public void NoZeroQuantity()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(1, 8);
            shoppingCart.AddToCart(1, -8);
            shoppingCart.AddToCart(2, 5);
            shoppingCart.AddToCart(2, -6);
            bool numberCheck = false;
            foreach(int x in shoppingCart.amountOfProduct)
            {
                if(x > 0)
                {
                    numberCheck = true;
                }
            }
            Assert.IsFalse(numberCheck);
        }

        //Check if shipping abroad is more expensive then inland
        [TestMethod]
        public void InlandCheaperThenAbroad()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(1, 8);
            Assert.IsTrue(shoppingCart.PriceOfCart(OrderType.Inland) < shoppingCart.PriceOfCart(OrderType.Abroad));
        }

        //Check if physical and digital products use their different methods
        [TestMethod]
        public void CheckDifferentMethodProducts()
        {
            PhysicalProduct physicalProduct = new PhysicalProduct("Product", 100, 100, "New Product");
            DigitalProduct digitalProduct = new DigitalProduct("Product", 100, 100, "New Product");
            Assert.IsFalse(physicalProduct.TransportMethod().Equals(digitalProduct.TransportMethod()));

        }

        [TestMethod]
        public void CheckOrderFulfilled()
        {
            Address address = new Address("", "", "", "", OrderType.Inland);
            ContactDetails contactDetails = new ContactDetails("", new MailAddress("test@test.nl"));
            Order order = new Order(1,address,contactDetails,PaymentMethod.CreditCard);
            int[] allProducts = new int[4];
            order.ProcessOrder(new ShoppingCart(allProducts), new Person(contactDetails,address));

            Assert.IsTrue(order.orderCreated);
        }

        [TestMethod]
        public void CheckOrderNotFulfilled()
        {
            Address address = new Address("", "", "", "", OrderType.Inland);
            ContactDetails contactDetails = new ContactDetails("", new MailAddress("test@test.nl"));
            Order order = new Order(1, address, contactDetails, PaymentMethod.CreditCard);
            Assert.IsFalse(order.orderCreated);
        }


    }
}
