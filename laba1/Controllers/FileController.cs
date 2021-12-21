using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using laba1.Models.File;

namespace laba1.Controllers
{
    public class FileController : Controller 
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStringLocalizer<HomeController> _localizer;

        public FileController(IWebHostEnvironment webHostEnvironment,
                               IStringLocalizer<HomeController> localizer)
        {
            _webHostEnvironment = webHostEnvironment;
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddYears(1) }
                );
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadFileViewModel vm)
        {
            string originalFileName = vm.File.FileName;

            string fileExtension = originalFileName.Split(".").Last();

            string newFileName = $"{vm.Name}.{fileExtension}";

            string filesDirectory = $"{_webHostEnvironment.WebRootPath}\\Files";

            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            string filePath = $"{filesDirectory}\\{newFileName}";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await vm.File.CopyToAsync(fileStream);
            }

            return Content("File has been uploaded.");
        }

        public IActionResult UploadFile()
        {
            return View();
        }
    }
}

