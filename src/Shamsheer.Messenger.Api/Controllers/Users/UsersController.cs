using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.Users;

namespace Shamsheer.Messenger.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet("Test")]
    public IActionResult GetNumbers([FromQuery] PaginationParams @params)
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        return Ok(numbers.ToPagedList(@params));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
        => Ok(await this._userService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await this._userService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._userService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserForUpdateDto dto)
        => Ok(await this._userService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._userService.RemoveAsync(id));

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(await this._userService.RetrieveByEmailAsync(email));
}
