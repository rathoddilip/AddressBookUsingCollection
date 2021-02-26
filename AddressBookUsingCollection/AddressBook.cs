using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsingCollection
{
    public class AddressBook
    {
        public List<Person> addressBook;
        public AddressBook()
        {
            addressBook = new List<Person>();
        }
        public void AddPersonToDictionary(Dictionary<string, List<Person>> personDictionary, Person person, string placeEntity)
        {
            if (personDictionary.ContainsKey(placeEntity))
            {
                personDictionary[placeEntity].Add(person);
            }
            else
            {
                List<Person> newList = new List<Person>();
                newList.Add(person);
                personDictionary.Add(placeEntity, newList);
            }
        }
        private void AddPersonToCityAndState(AddressBookCollection addressBookCollection, Person person)
        {
            AddPersonToDictionary(addressBookCollection.cityDictionary, person, person.city);
            AddPersonToDictionary(addressBookCollection.stateDictionary, person, person.state);
        }
        public void AddAddressBookEntry(Person person, AddressBookCollection addressBookCollection)
        {
            if (addressBook.Find(i => person.Equals(i)) != null)
            {
                throw new AddressBookException("Person already Exists, enter new person!");
            }
            AddPersonToCityAndState(addressBookCollection, person);
            addressBook.Add(person);


        }
        public void AddAddressBookEntry(AddressBookCollection addressBookCollection)
        {
            Person personEntered = new Person();
            Console.WriteLine("Enter First name");
            personEntered.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            personEntered.lastName = Console.ReadLine();
            if (addressBook.Find(i => personEntered.Equals(i)) != null)
            {
                Console.WriteLine("Person already Exists, enter new person!");
                return;
            }
            Console.WriteLine("Enter Address");
            personEntered.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            personEntered.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            personEntered.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            personEntered.zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            personEntered.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            personEntered.email = Console.ReadLine();
            AddPersonToCityAndState(addressBookCollection, personEntered);
            addressBook.Add(personEntered);
        }
        public void DisplayNamesInAddresBook()
        {
            if (addressBook.Count == 0)
            {
                Console.WriteLine("No Names to Display");
            }
            foreach (Person person in addressBook)
            {
                person.DisplayPerson();
            }
        }

        public void EditContact(string firstName, string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
            {
                Console.WriteLine("Enter First name");
                addressBook[index].firstName = Console.ReadLine();
                Console.WriteLine("Enter Last name");
                addressBook[index].lastName = Console.ReadLine();
                Console.WriteLine("Enter Address");
                addressBook[index].address = Console.ReadLine();
                Console.WriteLine("Enter City");
                addressBook[index].city = Console.ReadLine();
                Console.WriteLine("Enter State");
                addressBook[index].state = Console.ReadLine();
                Console.WriteLine("Enter Zip");
                addressBook[index].zip = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber");
                addressBook[index].phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Email");
                addressBook[index].email = Console.ReadLine();
            }
            else
                Console.WriteLine("Entry Not found for the name");
        }

        public void DeleteContact(string firstName, string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
                addressBook.Remove(addressBook[index]);
            else
                Console.WriteLine("Entry Not found");
        }
    }

}
