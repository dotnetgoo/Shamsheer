using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shamsheer.Service.Interfaces.Commons;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile image, string rootpath, string filePath);
    Task<bool> DeleteImageAsync(string subpath);
}