using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Email;

public interface IEmailVerificationService
{
     public Task<string> SendMessageAsync(string toEmail);
     public string GenerateCode();
}
