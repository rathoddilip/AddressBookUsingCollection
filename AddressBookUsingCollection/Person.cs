using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsingCollection
{
    public class Person 
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Person))
            {
                return false;
            }
            return (this.firstName == ((Person)obj).firstName)
                && (this.lastName == ((Person)obj).lastName);
        }
        public void DisplayPerson()
        {
            Console.WriteLine("First Name :"+ firstName);
            Console.WriteLine("Last Name :"+ lastName);
            Console.WriteLine("Address :"+ address);
            Console.WriteLine("City : "+city);
            Console.WriteLine("State : "+state);
            Console.WriteLine("Zip :"+zip);
            Console.WriteLine("PhoneNumber :"+ phoneNumber);
            Console.WriteLine("Email :"+email);
        }
    }
}
