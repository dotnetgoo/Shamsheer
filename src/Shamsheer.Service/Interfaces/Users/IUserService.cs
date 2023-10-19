using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces.Users
{
    public interface IUserService
    {
        Task<bool> RemoveAsync(long id);
        Task<UserForResultDto> RetrieveByIdAsync(long id);
        Task<IEnumerable<UserForResultDto>> RetrieveAllAsync();
        Task<UserForResultDto> AddAsync(UserForCreationDto dto);
        Task<UserForResultDto> RetrieveByEmailAsync(string email);
        Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    }
}
