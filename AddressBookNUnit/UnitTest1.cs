using NUnit.Framework;
using AddressBookUsingCollection;
using System.Collections;

namespace AddressBookNUnit
{
    public class Tests
    {
        AddressBookCollection addressBookCollection;
        [SetUp]
        public void Setup()
        {
            addressBookCollection = new AddressBookCollection();
            
        }
        //UC8

        [TestCase("Dilip", "Rathod")]
        public void GivenAddressBookSearchPersonInCityOrStateEntryNotPresent(string firstName, string lastName)
        {
            ArrayList expectedOutputLines = new ArrayList();
            ArrayList outputLines = addressBookCollection.SearchPersonInCityOrState(firstName, lastName);
            Assert.AreEqual(expectedOutputLines, outputLines);
        }
        

    }
}