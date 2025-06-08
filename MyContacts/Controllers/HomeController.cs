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

            return View(contacts);
        }
    }
}
