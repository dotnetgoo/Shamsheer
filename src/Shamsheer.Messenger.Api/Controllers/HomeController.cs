using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.DbContexts;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class HomeController : ControllerBase
    {
        private readonly ShamsheerDbContext _dbContext;

        public HomeController(ShamsheerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<User> GetByIdAsync(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
