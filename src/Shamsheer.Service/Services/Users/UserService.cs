using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Interfaces.Users;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Configurations.Filters;
using System.Reflection;

namespace Shamsheer.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            var users = await _userRepository.SelectAll()
                .Where(u => u.Phone == dto.Phone)
                .FirstOrDefaultAsync();

            if (users is not null)
                throw new ShamsheerException(409, "User is already exist.");

            var mappedUser = _mapper.Map<User>(dto);
            mappedUser.CreatedAt = DateTime.UtcNow;

            var createdUser = await _userRepository.InsertAsync(mappedUser);
            return _mapper.Map<UserForResultDto>(mappedUser);
        }

        public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if (user is null)
                throw new ShamsheerException(404, "User not found");

            user.UpdatedAt = DateTime.UtcNow;
            var person = _mapper.Map(dto, user);

            await _userRepository.UpdateAsync(person);

            return _mapper.Map<UserForResultDto>(person);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if (user is null)
                throw new ShamsheerException(404, "User is not found");

            await _userRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var users = await _userRepository.SelectAll()
                .Include(a => a.Assets)
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserForResultDto>>(users);
        }

        public async Task<UserForResultDto> RetrieveByEmailAsync(string email)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();
            if (user is null)
                throw new ShamsheerException(404, "User Not Found");

            return _mapper.Map<UserForResultDto>(user);
        }

        public async Task<UserForResultDto> RetrieveByIdAsync(long id)
        {
            var users = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .Include(a => a.Assets)
                .FirstOrDefaultAsync();
            if (users is null)
                throw new ShamsheerException(404, "User is not found");

            return _mapper.Map<UserForResultDto>(users);
        }

        public async Task<UserForResultDto> RetrieveByFilterAsync(GetFilter filter)
        {
            var props = typeof(User).GetProperties(BindingFlags.Public).Select(p => p.Name);
            if (!props.Contains(filter.Property))
                throw new ShamsheerException(400, "Property not found");

            // something

            var users = await _userRepository.SelectAll()
                .Where(u => u.Id.ToString() == filter.Property)
                .Include(a => a.Assets)
                .FirstOrDefaultAsync();
            if (users is null)
                throw new ShamsheerException(404, "User is not found");

            return _mapper.Map<UserForResultDto>(users);
        }
    }
}
