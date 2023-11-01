using Shamsheer.Service.DTOs.Users;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Users;

public interface IAuthService
{
    public Task<LoginResultDto> AuthenticateAsync(LoginDto login);
}
