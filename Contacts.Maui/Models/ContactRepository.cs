using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    internal static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact {Name="Aadi Sharma", Email="asharma@mitre.org"},
            new Contact {Name="Frank", Email="frank@mitre.org"},
            new Contact {Name="Joe Biden", Email="jbiden@secretservice.org"},

        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }
    }
}
