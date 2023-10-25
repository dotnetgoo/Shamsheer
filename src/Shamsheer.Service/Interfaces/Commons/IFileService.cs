using System.IO;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Commons;

public interface IFileService
{
    Task<string> UploadAsync(Stream file, string path);
    Task<byte[]> DownloadAsync(string path);
    Task<bool> DeleteAsync(string path);
}