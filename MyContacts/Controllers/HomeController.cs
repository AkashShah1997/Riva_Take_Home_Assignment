using Microsoft.AspNetCore.Mvc;
using MyContacts.Services;
using System.Diagnostics;

namespace MyContacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactService _service;

        public HomeController(ContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var contacts = _service.GetAllContacts()
                .OrderBy(c => c.LastName)
                .ToList();

            // Ensure category object is populated manually
            foreach (var contact in contacts)
            {
                contact.Category = _service.GetCategory(contact.CategoryId.Value);
            }

            return View(contacts);
        }
    }
}
