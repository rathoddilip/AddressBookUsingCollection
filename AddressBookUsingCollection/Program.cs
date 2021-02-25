using System;

namespace AddressBookUsingCollection
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book!");
            Console.WriteLine("Enter Default Address Book Name");
            string addressBookName = Console.ReadLine();
            AddressBookCollection addressBookCollection = new AddressBookCollection();
            AddressBook addressBook = new AddressBook();
            addressBookCollection.addressBookDictionary.Add(addressBookName, addressBook);
            int choice;
            do
            {
                Console.WriteLine("1) Display All Entries");
                Console.WriteLine("2) Insert new Contact");
                Console.WriteLine("3) Edit Contact");
                Console.WriteLine("4) Delete Contact");
                Console.WriteLine("5) Add New Address Book");
                Console.WriteLine("6) List of all Address Book");
                Console.WriteLine("7) Search person in city or state");
                Console.WriteLine("8) View person by state or city");
                Console.WriteLine("9) View Count by state or city");
                Console.WriteLine("10) Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookCollection.addressBookDictionary[addressBookName].DisplayNamesInAddresBook();
                        break;
                    case 2:
                        addressBookCollection.addressBookDictionary[addressBookName].AddAddressBookEntry(addressBookCollection);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].EditContact(firstName, lastName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].DeleteContact(firstName, lastName);
                        break;
                    case 5:
                        Console.WriteLine("Enter New Address Book Name");
                        addressBookName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary.Add(addressBookName, new AddressBook());
                        Console.WriteLine($"Address Book {addressBookName} selected!");
                        break;
                    case 6:
                        Console.WriteLine("Listing all Address Books");
                        foreach (var addressBookEntry in addressBookCollection.addressBookDictionary)
                        {
                            Console.WriteLine(addressBookEntry.Key);
                        }
                        Console.WriteLine("Select an Address Book");
                        addressBookName = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.SearchPersonInCityOrState(firstName, lastName);
                        break;
                    case 8:
                        Console.WriteLine("Enter City Name");
                        string cityName = Console.ReadLine();
                        Console.WriteLine("Enter State Name");
                        string stateName = Console.ReadLine();
                        addressBookCollection.ViewPersonsByCityOrState(cityName, stateName);
                        break;
                    case 9:
                        Console.WriteLine("Enter City name");
                        cityName = Console.ReadLine();
                        Console.WriteLine("Enter state name");
                        stateName = Console.ReadLine();
                        addressBookCollection.ViewCountByCityOrState(cityName, stateName);
                        break;
                    case 10:
                        Console.WriteLine("Thank you");
                        break;
                    default:
                        Console.WriteLine("please enter proper choice");
                        break;
                }
            } while (choice != 10);
        }
    }
    }
