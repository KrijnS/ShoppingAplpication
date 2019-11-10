using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    class Person
    {
        ContactDetails contactDetails;
        Address address;

        public Person(ContactDetails contactDetails, Address address)
        {
            this.contactDetails = contactDetails;
            this.address = address;
        }

        public Person GetPerson()
        {
            Address address = new Address("", "", "", "", OrderType.Inland);
            address = address.GetAddress();
            ContactDetails contactDetails = new ContactDetails("", null);
            contactDetails = contactDetails.GetContactDetails();

            return new Person(contactDetails, address);
        }
    }
}
