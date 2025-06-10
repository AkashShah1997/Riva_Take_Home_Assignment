using MyContacts.Models;

namespace MyContacts.Services
{
    public class ContactService
    {
        private List<Contact> _contacts;
        private int _nextId = 4;

        public ContactService()
        {
            _contacts = new List<Contact>
            {
                new Contact { ContactId = 1, FirstName = "Scott", LastName = "Gudmestad", PhoneNumber = "123-456-7890", Email = "sgudmestad@gmail.com", DateAdded = DateTime.Now },
                new Contact { ContactId = 2, FirstName = "Gerry", LastName = "Gudmestad", PhoneNumber = "123-456-7890", Email = "ggudmestad@gmail.com", DateAdded = DateTime.Now },
                new Contact { ContactId = 3, FirstName = "Blake", LastName = "Boyer", PhoneNumber = "123-456-7890", Email = "bboyer@gmail.com", DateAdded = DateTime.Now }
            };
        }

        public List<Contact> GetAllContacts() => _contacts;
        public Contact? GetContact(int id) => _contacts.FirstOrDefault(c => c.ContactId == id);

        public void AddContact(Contact contact)
        {
            contact.ContactId = _nextId++;
            contact.DateAdded = DateTime.Now;
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            var existing = GetContact(contact.ContactId);
            if (existing != null)
            {
                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.PhoneNumber = contact.PhoneNumber;
                existing.Email = contact.Email;
            }
        }

        public void DeleteContact(int id)
        {
            var contact = GetContact(id);
            if (contact != null) _contacts.Remove(contact);
        }
    }
}
