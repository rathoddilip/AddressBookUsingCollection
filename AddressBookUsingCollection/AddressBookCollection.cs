using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        private List<Person> GetPeopleFromFile(string filepath)
        {
            List<Person> people = new List<Person>();
            string[] lines = File.ReadAllLines(filepath);
            int noOfRecords = lines.Length / 8;
            for (int i = 1; i <= noOfRecords; i++)
            {
                Person person = new Person();
                person.firstName = lines[0 * i].Split(':')[1];
                person.lastName = lines[1 * i].Split(':')[1];
                person.address = lines[2 * i].Split(':')[1];
                person.city = lines[3 * i].Split(':')[1];
                person.state = lines[4 * i].Split(':')[1];
                person.zip = lines[5 * i].Split(':')[1];
                person.phoneNumber = lines[6 * i].Split(':')[1];
                person.email = lines[7 * i].Split(':')[1];
                people.Add(person);
            }
            return people;
        }
        /// <summary>
        /// UC13: Read files to addressbook
        /// </summary>
        public void ReadFilesToAddressBookCollection()
        {
            string folderPath = @"C:\Users\Dilip Rathod\Desktop\Bridgelab\BatchDotNetFellowship-015\AddressBookUsingCollection\AddressBookUsingCollection\Files\";
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            foreach (var file in directoryInfo.GetFiles("*.txt"))
            {
                string addressBookName = file.Name.Replace(".txt", "");
                if (!this.addressBookDictionary.ContainsKey(addressBookName))
                {
                    this.addressBookDictionary.Add(addressBookName, new AddressBook());
                    List<Person> people = GetPeopleFromFile(folderPath + file.Name);
                    this.addressBookDictionary[addressBookName].addressBook = people;
                }

            }

            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        writer.WriteLine($"First Name : {person.firstName}");
                        writer.WriteLine($"Last Name : {person.lastName}");
                        writer.WriteLine($"Address : {person.address}");
                        writer.WriteLine($"City : {person.city}");
                        writer.WriteLine($"State : {person.state}");
                        writer.WriteLine($"Zip : {person.zip}");
                        writer.WriteLine($"PhoneNumber : {person.phoneNumber}");
                        writer.WriteLine($"Email : {person.email}");
                    }
                }


            }
        }
        /// <summary>
        /// UC13- Write Addressbook to files
        /// </summary>
        public void WriteAddressBookCollectionToFiles()
        {
            string folderPath = @"C:\Users\Dilip Rathod\Desktop\Bridgelab\BatchDotNetFellowship-015\AddressBookUsingCollection\AddressBookUsingCollection\Files\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        writer.WriteLine($"First Name : {person.firstName}");
                        writer.WriteLine($"Last Name : {person.lastName}");
                        writer.WriteLine($"Address : {person.address}");
                        writer.WriteLine($"City : {person.city}");
                        writer.WriteLine($"State : {person.state}");
                        writer.WriteLine($"Zip : {person.zip}");
                        writer.WriteLine($"PhoneNumber : {person.phoneNumber}");
                        writer.WriteLine($"Email : {person.email}");
                    }
                }

            }
        }
        /// <summary>
        /// Writes the address book collection to files CSV.
        /// </summary>
        public void WriteAddressBookCollectionToFilesCSV()
        {
            string folderPath = @"C:\Users\Dilip Rathod\Desktop\Bridgelab\BatchDotNetFellowship-015\AddressBookUsingCollection\AddressBookUsingCollection\csvFiles\";
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IncludePrivateMembers = true,
            };
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".csv";
                using (StreamWriter writer = new StreamWriter(filePath))
                using (var csvExport = new CsvWriter(writer, configuration))
                {
                  // csvExport.WriteRecords(AddressBookItem.Value.addressBook);
                    csvExport.WriteHeader<Person>();
                    csvExport.NextRecord();
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        csvExport.WriteField($"{person.firstName}");
                        csvExport.WriteField($"{person.lastName}");
                        csvExport.WriteField($"{person.address}");
                        csvExport.WriteField($"{person.city}");
                        csvExport.WriteField($"{person.state}");
                        csvExport.WriteField($"{person.zip}");
                        csvExport.WriteField($"{person.phoneNumber}");
                        csvExport.WriteField($"{person.email}");
                        csvExport.NextRecord();
                    }
                    
                }
            }
        }
        /// <summary>
        /// Reads the files to address book collection CSV.
        /// </summary>
        public void ReadFilesToAddressBookCollectionCSV()
        {
            string folderPath = @"C:\Users\Dilip Rathod\Desktop\Bridgelab\BatchDotNetFellowship-015\AddressBookUsingCollection\AddressBookUsingCollection\csvFiles\";
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            foreach (var file in directoryInfo.GetFiles("*.csv"))
            {
                string addressBookName = file.Name.Replace(".csv", "");
                if (!this.addressBookDictionary.ContainsKey(addressBookName))
                {
                    this.addressBookDictionary.Add(addressBookName, new AddressBook());
                    using (var reader = new StreamReader(folderPath + file.Name))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        List<Person> people = csv.GetRecords<Person>().ToList();
                        this.addressBookDictionary[addressBookName].addressBook = people;
                        reader.Close();
                        Console.WriteLine("Successfully read records from the file " + file.Name);
                    }
                }
            }
        }

    }
}
