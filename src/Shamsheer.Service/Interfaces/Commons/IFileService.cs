using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shamsheer.Service.Interfaces.Commons;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image, string rootpath, string filePath);
    public Task<bool> DeleteImageAsync(string subpath);
}