using Microsoft.AspNetCore.Http;

namespace laba1.Models.File
{
    public class UploadFileViewModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}