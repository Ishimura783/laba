using laba1.Models;
using laba1.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Services.EmailService;


namespace laba1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;


        public HomeController(ILogger<HomeController> logger,IEmailSender emailSender)
        {
            _logger = logger ;
            _emailSender = emailSender;
        }

        public  IActionResult Index()
        {
            
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> SendEmail([FromForm] EmailSenderVM vm)
        {
            await _emailSender.SendMessage(vm.EmailTo, vm.MessageBody, vm.Subject);
            return Json(new { success = true });
        }

    }
}
