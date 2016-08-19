using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Data
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        void Add(Contact newContact);
        void Delete(int id);
        void Edit(Contact contact);
        Contact GetById(int id);
    }
}
