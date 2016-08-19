using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Data
{
    public class ContactRepository : IContactRepository
    {
        private string _fileName = "DataFiles/contacts.txt";

        public List<Contact> GetAll()
        {
            List<Contact> allContacts = new List<Contact>();

            if (File.Exists(_fileName))
            {
                using (var reader = File.OpenText(_fileName))
                {
                    //read the header line
                    reader.ReadLine();

                    string inputLine;
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        var columns = inputLine.Split(',');
                        var contact = new Contact()
                        {
                            ContactID = int.Parse(columns[0]),
                            Name = columns[1],
                            PhoneNumber = columns[2]
                        };

                        allContacts.Add(contact);
                    }
                }
            }

            return allContacts;
        }

        public void Add(Contact newContact)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newContact.ContactID = (GetAll().Any()) ? GetAll().Max(c => c.ContactID) + 1 : 1;

            var contacts = GetAll();
            contacts.Add(newContact);

            WriteFile(contacts);
        }

        public void Delete(int id)
        {
            var contacts = GetAll();
            contacts.RemoveAll(c => c.ContactID == id);

            WriteFile(contacts);
        }

        public void Edit(Contact contact)
        {
            var contacts = GetAll();
            contacts.RemoveAll(c => c.ContactID == contact.ContactID);
            contacts.Add(contact);

            WriteFile(contacts);
        }

        public Contact GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.ContactID == id);
        }

        private void WriteFile(List<Contact> contacts)
        {
            using (var writer = File.CreateText(_fileName))
            {
                writer.WriteLine("Id,Name,PhoneNumber");

                foreach (Contact contact in contacts)
                {
                    writer.WriteLine(String.Format("{0},{1},{2}", contact.ContactID, contact.Name, contact.PhoneNumber));
                }
            }
        }
    }
}
