using laba1.Models.Contact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba1.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> CreateContact(ContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactUs");
            }
            return View("ContactUs");
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
