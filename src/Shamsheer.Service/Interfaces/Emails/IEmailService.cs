using Shamsheer.Domain.Entities;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Emails;

public interface IEmailVerificationService
{
    public Task SendMessageAsync(EmailVerification verification);
}
