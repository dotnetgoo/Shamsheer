using AutoMapper;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> AddAsync(UserForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User> ModifyAsync(UserForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> RetrieveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> RetrieveByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> RetrieveByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
