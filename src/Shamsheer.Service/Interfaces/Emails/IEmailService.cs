using Shamsheer.Domain.Entities;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Emails;

public interface IEmailService
{
    public Task SendMessage(ShamsheerVerification message);
}
