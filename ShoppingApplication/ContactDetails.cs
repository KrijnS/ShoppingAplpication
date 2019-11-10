using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class ContactDetails
    {
        public string name;
        public MailAddress email;

        public ContactDetails(string name, MailAddress email)
        {
            this.name = name;
            this.email = email;
        }

        public string GetName()
        {
            Console.WriteLine("Please input your name");
            string name = Console.ReadLine();
            Regex regex = new Regex("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");
            if (!(regex.IsMatch(name)))
            {
                return GetName();
            }
            else
            {
                return name;
            }
        }

        public MailAddress GetEmail()
        {
            Console.WriteLine("Please input your email");
            string email = Console.ReadLine();
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return mailAddress;
            }
            catch
            {
                return GetEmail();
            }
        }

        public ContactDetails GetContactDetails()
        {
            return new ContactDetails(GetName(), GetEmail());
        }
    }
}
