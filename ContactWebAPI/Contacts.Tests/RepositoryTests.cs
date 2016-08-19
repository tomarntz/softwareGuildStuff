using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data;
using Contacts.Models;
using NUnit.Framework;

namespace Contacts.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void AddNewTest()
        {
            var repo = Factory.CreateContactRepository();
            var results = repo.GetAll();
            var count = results.Count;

            Contact newContact = new Contact()
            {
                Name = "Homer Simpson",
                PhoneNumber = "555-5055"
            };

            repo.Add(newContact);

            var newResults = repo.GetAll();

            Assert.AreEqual(count + 1, newResults.Count);
        }
    }
}
