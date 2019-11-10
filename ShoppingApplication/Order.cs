using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Order
    {
        int orderID;
        Address address;
        ContactDetails contactDetails;
        PaymentMethod paymentMethod;
        public bool orderCreated;

        //Basic constructor for Order class
        public Order(int orderID, Address address, ContactDetails contactDetails, PaymentMethod paymentMethod)
        {
            this.orderID = orderID;
            this.address = address;
            this.contactDetails = contactDetails;
            this.paymentMethod = paymentMethod;
        }

        //Finalize order by getting contact details
        public void CompleteOrder(ShoppingCart shoppingCart)
        {
            Person person = new Person(null, null);
            person = person.GetPerson();
            Parser parser = new Parser();

            Console.WriteLine("\nYour address has been recorded, now to the payment\nYour total is: "
                + shoppingCart.PriceOfCart(address.orderType) + " euros");
            
            if (VerifyPayment())
            {
                ProcessOrder(shoppingCart, person);
            }
        }


        //Checks to see if the payment was successfull
        public bool VerifyPayment()
        {
            orderCreated = false;
            Console.WriteLine("Payment initiated...\nWas payment succesfull? [Y|N]");
            ResponseHandler responseHandler = new ResponseHandler();
            if (responseHandler.ParseYesNo())
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nPayment was not succesfull, try again");
                return VerifyPayment();
            }
        }

        //Processes order after succesfull verification
        public void ProcessOrder(ShoppingCart shoppingCart, Person person)
        {
            Parser parser = new Parser();
            OrderID orderID = new OrderID();
            Order order = new Order(orderID.GenerateID(), address, contactDetails, paymentMethod);
            WriteOrderToFile(order);
            for (int i = 0; i < shoppingCart.amountOfProduct.Length; i++)
            {
                if (shoppingCart.amountOfProduct[i] > 0)
                {
                    Product tempProduct = parser.GetProductFromIndex(i);
                    if (tempProduct.GetType() == typeof(DigitalProduct))
                    {
                        for (int j = 0; j < shoppingCart.amountOfProduct[i]; j++)
                        {
                            Console.WriteLine(tempProduct.TransportMethod());
                        }
                    }
                    else
                    {
                        Console.WriteLine(shoppingCart.amountOfProduct[i] + "x " + tempProduct.TransportMethod());
                    }
                }
            }
        }

        //Get type of PaymentMethod
        public PaymentMethod GetPaymentMethod()
        {
            Console.WriteLine("Please input the variation of payment, as \u0022iDeal\u0022, \u0022CreditCard\u0022 or \u0022PayPal\u0022");
            string input = Console.ReadLine();
            switch (input)
            {
                case "iDeal":
                    return PaymentMethod.iDeal;
                case "CreditCard":
                    return PaymentMethod.CreditCard;
                case "PayPal":
                    return PaymentMethod.Paypal;
                default:
                    return GetPaymentMethod();
            }
        }

        //Writes order info to Console, can easily be redesigned to email
        public void WriteOrderToFile(Order order)
        {
            orderCreated = true;
            Console.WriteLine("Order " + order.orderID + " completed by " + order.contactDetails.name + ", sent to " + order.contactDetails.email
                + "\nAt " + order.address.street + " " + order.address.houseNumber + " in " + order.address.city);
        }
    }
}
