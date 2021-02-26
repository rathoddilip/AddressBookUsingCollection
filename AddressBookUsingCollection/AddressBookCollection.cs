using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsingCollection
{
    public class AddressBookCollection
    {
        public Dictionary<string, AddressBook> addressBookDictionary;
        public Dictionary<string, List<Person>> cityDictionary;
        public Dictionary<string, List<Person>> stateDictionary;
        public AddressBookCollection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
            cityDictionary = new Dictionary<string, List<Person>>();
            stateDictionary = new Dictionary<string, List<Person>>();
        }
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
        public void SearchPersonInCityOrState(string firstName, string lastName)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.firstName == firstName) && (i.lastName == lastName));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                }
            }
        }
        public void ViewPersonsByCityOrState(string city, string state)
        {
            Console.WriteLine($"People in {city} city:");
            foreach (Person person in cityDictionary[city])
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
            }

            Console.WriteLine($"People in {state} state:");
            foreach (Person person in stateDictionary[state])
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
            }
        }
        public void ViewCountByCityOrState(string city, string state)
        {
            var arrayList = new ArrayList();

            arrayList.Add("Count of " + city + " is " + cityDictionary[city].Count);
            arrayList.Add("Count of " + state + " is " + stateDictionary[state].Count);
            Console.WriteLine("Count of  " + city + " is " + cityDictionary[city].Count);
            Console.WriteLine("Count of " + state + " is " + stateDictionary[state].Count);
        }
    }
}
