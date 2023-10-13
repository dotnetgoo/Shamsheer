using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(UserForCreationDto dto);
        Task<IEnumerable<User>> RetrieveAllAsync();
        Task<User> RetrieveByIdAsync(long id);
        Task<User> RetrieveByEmailAsync(string email);
        Task<User> ModifyAsync(UserForUpdateDto dto);
        Task<bool> RemoveAsync(long id);
    }
}
