using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingApplication;

namespace ShoppingApplicationTests
{
    [TestClass]
    public class UnitTest1
    {
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

        [TestMethod]
        public void NoZeroQuantity()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(1, 8);
            shoppingCart.AddToCart(1, -8);
            
        }

        [TestMethod]
        public void InlandCheaperThenAbroad()
        {
            string[] allLines = File.ReadAllLines("Database.txt", Encoding.UTF8);
            int[] allProducts = new int[allLines.Length];
            ShoppingCart shoppingCart = new ShoppingCart(allProducts);
            shoppingCart.AddToCart(1, 8);
            Assert.IsTrue(shoppingCart.PriceOfCart(OrderType.Inland) < shoppingCart.PriceOfCart(OrderType.Abroad));
        }

    }
}
