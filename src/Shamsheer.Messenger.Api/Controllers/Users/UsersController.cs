using Microsoft.AspNetCore.Mvc;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Interfaces;

namespace Shamsheer.Messenger.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.AddAsync(dto)
        });

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserForUpdateDto dto)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.RemoveAsync(id)
        });

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.userService.RetrieveByEmailAsync(email)
        });
}
