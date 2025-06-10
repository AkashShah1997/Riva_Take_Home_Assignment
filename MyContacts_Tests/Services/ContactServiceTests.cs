using MyContacts.Models;
using MyContacts.Services;
using System;
using System.Linq;
using Xunit;

namespace MyContacts.Tests
{
    public class ContactServiceTests
    {
        private readonly ContactService _service;

        public ContactServiceTests()
        {
            _service = new ContactService();
        }

        [Fact]
        public void GetAllContacts_ShouldReturnInitialContacts()
        {
            var contacts = _service.GetAllContacts();
            Assert.Equal(3, contacts.Count);
        }

        [Fact]
        public void GetContact_ValidId_ShouldReturnContact()
        {
            var contact = _service.GetContact(1);
            Assert.NotNull(contact);
            Assert.Equal("Scott", contact.FirstName);
        }

        [Fact]
        public void GetContact_InvalidId_ShouldReturnNull()
        {
            var contact = _service.GetContact(999);
            Assert.Null(contact);
        }

        [Fact]
        public void AddContact_ShouldIncreaseCount()
        {
            var newContact = new Contact { FirstName = "New", LastName = "User", Email = "test@email.com", PhoneNumber = "111-111-1111" };
            _service.AddContact(newContact);

            var contacts = _service.GetAllContacts();
            Assert.Equal(4, contacts.Count);
            Assert.Contains(contacts, c => c.FirstName == "New" && c.ContactId == 4);
        }

        [Fact]
        public void UpdateContact_ShouldModifyExisting()
        {
            var contact = _service.GetContact(1);
            contact.FirstName = "Updated";

            _service.UpdateContact(contact);

            var updated = _service.GetContact(1);
            Assert.Equal("Updated", updated.FirstName);
        }

        [Fact]
        public void DeleteContact_ShouldRemoveContact()
        {
            _service.DeleteContact(1);
            var contact = _service.GetContact(1);
            Assert.Null(contact);
        }
    }
}
