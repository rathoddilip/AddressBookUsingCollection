using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsingCollection
{
    public class AddressBookException : Exception
    {
        public AddressBookException(string name) : base()
        {
            Console.WriteLine(name);
        }
    }
}
