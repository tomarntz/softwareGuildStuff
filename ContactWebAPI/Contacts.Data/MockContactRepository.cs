using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Data
{
    public class MockContactRepository : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>();

        public MockContactRepository()
        {
            if (!_contacts.Any())
            {
                _contacts.AddRange(new List<Contact>()
                {
                    new Contact {ContactID = 1, Name = "Victor Pudelski", PhoneNumber = "876-5309"},
                    new Contact {ContactID = 2, Name = "Randall Clapper", PhoneNumber = "555-5555"}
                });
            }
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public void Add(Contact newContact)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newContact.ContactID = (_contacts.Any()) ? _contacts.Max(c => c.ContactID) + 1 : 1;

            _contacts.Add(newContact);
        }

        public void Delete(int id)
        {
            _contacts.RemoveAll(c => c.ContactID == id);
        }

        public void Edit(Contact contact)
        {
            Delete(contact.ContactID);
            _contacts.Add(contact);
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.ContactID == id);
        }
    }
}
