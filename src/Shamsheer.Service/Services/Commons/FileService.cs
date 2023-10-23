using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using Shamsheer.Service.Interfaces.Commons;

namespace Shamsheer.Service.Services.Commons;

public class FileService : IFileService
{
    private readonly string MEDIA = "Media";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);

        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        return false;
    }

    public async Task<string> UploadImageAsync(IFormFile image, string rootpath, string filePath)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName, filePath);
        string subPath = Path.Combine(MEDIA, filePath, rootpath, newImageName);
        string path = Path.Combine(ROOTPATH, subPath);
        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subPath;
    }
}
