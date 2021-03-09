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
        public ArrayList SearchPersonInCityOrState(string firstName, string lastName)
        {
            ArrayList outputLines = new ArrayList();
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.firstName == firstName) && (i.lastName == lastName));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                    outputLines.Add($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                }
            }
            return outputLines;
        }
        public ArrayList ViewPersonsByCityOrState(string city, string state)
        {
            ArrayList outputLines = new ArrayList();
            Console.WriteLine($"People in {city} city:");
            outputLines.Add($"People in {city} city:");
            foreach (Person person in cityDictionary[city])
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
                outputLines.Add(person.firstName + " " + person.lastName);
            }

            Console.WriteLine($"People in {state} state:");
            outputLines.Add($"People in {state} state:");
            foreach (Person person in stateDictionary[state])
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
                outputLines.Add(person.firstName + " " + person.lastName);
            }
            return outputLines;
        }
        public ArrayList ViewCountByCityOrState(string city, string state)
        {
            ArrayList outputLines = new ArrayList();
            outputLines.Add($"Count of {city} is {cityDictionary[city].Count}");
            outputLines.Add($"Count of {state} is {stateDictionary[state].Count}");
            Console.WriteLine($"Count of {city} is {cityDictionary[city].Count}");
            Console.WriteLine($"Count of {state} is {stateDictionary[state].Count}");
            return outputLines;
        }
       

    }
}
