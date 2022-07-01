using System.Collections.Generic;

namespace patientlist.Models
{
    public class ContactList
    {
        private readonly List<Contact> _contacts;

        public ContactList()
        {
            _contacts = new List<Contact>();
        }

        public IEnumerable<Contact> GetAllContacts() => _contacts;

        public void AddContact(Contact newContact)
        {
            _contacts.Add(newContact);
        }
        
        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }
    }
}
