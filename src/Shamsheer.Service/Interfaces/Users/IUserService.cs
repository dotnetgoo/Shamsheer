using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Configurations.Filters;
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
        Task<UserForResultDto> RetrieveByFilterAsync(GetFilter filter);
        Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<UserForResultDto> AddAsync(UserForCreationDto dto);
        Task<UserForResultDto> RetrieveByEmailAsync(string email);
        Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    }
}
