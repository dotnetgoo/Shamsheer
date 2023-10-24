using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Interfaces.Commons;

namespace Shamsheer.Messenger.Api.Controllers
{
    public class FilesController : BaseController
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Media", "Files", file.FileName);
            
            return Ok(await _fileService.UploadAsync(file.OpenReadStream(), path));
        }

        [HttpGet]
        public async Task<IActionResult> DownloadAsync(string relativePath)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, relativePath);
            string fileName = Path.GetFileName(path);

            return File(await _fileService.DownloadAsync(path), "application/octet-stream", fileName);
        }
    }
}
