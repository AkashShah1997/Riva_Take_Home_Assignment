
using Microsoft.AspNetCore.Mvc;
using MyContacts.Models;
using MyContacts.Services;

namespace MyContacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _service;

        public ContactController(ContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var contacts = _service.GetAllContacts();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            if (id == null || id == 0)
            {
                ViewBag.Action = "Add";
                return PartialView("AddEdit", new Contact());
            }

            var contact = _service.GetContact(id.Value);
            if (contact == null) return NotFound();

            ViewBag.Action = "Edit";
            return PartialView("AddEdit", contact);
        }

        [HttpPost]
        public IActionResult AddEdit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                    _service.AddContact(contact);
                else
                    _service.UpdateContact(contact);

                var contacts = _service.GetAllContacts();
                return PartialView("Details", contacts);
            }

            ViewBag.Action = contact.ContactId == 0 ? "Add" : "Edit";
            return PartialView("AddEdit", contact);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeleteContact(id);
            var contacts = _service.GetAllContacts();
            return PartialView("Details", contacts);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _service.GetContact(id);
            return contact == null ? NotFound() : View(contact);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var results = _service.GetAllContacts();

            if (!string.IsNullOrEmpty(query))
            {
                query = query.ToLower();
                results = results.Where(c =>
                    (!string.IsNullOrEmpty(c.FirstName) && c.FirstName.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(c.LastName) && c.LastName.ToLower().Contains(query))
                ).ToList();
            }

            return PartialView("Details", results);
        }

    }
}