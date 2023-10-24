using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using Shamsheer.Service.Interfaces.Commons;

namespace Shamsheer.Service.Services.Commons;

public class FileService : IFileService
{
    public async Task<bool> DeleteAsync(string path)
    {
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

    public async Task<byte[]> DownloadAsync(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();

        return await File.ReadAllBytesAsync(path);
    }

    public async Task<string> UploadAsync(Stream file, string path)
    {
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            
            await stream.FlushAsync();
            stream.Close();
        };        

        return path;
    }
}
