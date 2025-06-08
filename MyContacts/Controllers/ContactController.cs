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
        public IActionResult Add()
        {
            ViewBag.Categories = _service.GetCategories();
            ViewBag.Action = "Add";
            return View("AddEdit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _service.GetContact(id);
            if (contact == null) return NotFound();
            ViewBag.Categories = _service.GetCategories();
            ViewBag.Action = "Edit";
            return View("AddEdit", contact);
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

                return RedirectToAction("Index");
            }

            ViewBag.Categories = _service.GetCategories();
            return View("AddEdit", contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _service.GetContact(id);
            return contact == null ? NotFound() : View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _service.DeleteContact(contact.ContactId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _service.GetContact(id);
            if (contact != null)
            {
                contact.Category = _service.GetCategory(contact.CategoryId.Value);
            }
            return contact == null ? NotFound() : View(contact);
        }
    }
}
