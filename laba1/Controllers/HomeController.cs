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
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace laba1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public HomeController(ILogger<HomeController> logger,IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger ;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public  IActionResult Index()
        {

            var currentUrl = _httpContextAccessor.HttpContext.Request.GetEncodedUrl();
            // Получение имени компьютера.
            String host = Dns.GetHostName();
            // Получение ip-адреса.
            IPAddress ip = Dns.GetHostByName(host).AddressList[0];
            _logger.LogInformation($"Url: {currentUrl}, Time: {DateTime.Now}, IP Address: {ip}");
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
