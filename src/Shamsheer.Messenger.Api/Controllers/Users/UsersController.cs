using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Shamsheer.Service.Configurations.Filters;

namespace Shamsheer.Messenger.Api.Controllers.Users;

[Authorize]
public class UsersController : BaseController
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UsersController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration=configuration;
    }

    [HttpGet("Test")]
    public IActionResult GetNumbers([FromQuery] PaginationParams @params)
    {   
        string credentialsBase64 = Request.Headers["Authorization"].ToString().Split(' ')[1];
        string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(credentialsBase64));
        string username = credentials.Split('.')[0];
        string password = credentials.Split(".")[1];

        var _username = _configuration["Click:Username"];
        var _password = _configuration["Click:Password"];
        string _url = _configuration["Click:Url"];

        if (username == _username && password == _password)
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return Ok(numbers.ToPagedList(@params));
        }

        return Unauthorized();
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
        => Ok(await _userService.AddAsync(dto));

    [HttpGet, Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserForUpdateDto dto)
        => Ok(await _userService.ModifyAsync(id, dto));

    [Authorize("Department")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userService.RemoveAsync(id));

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(await _userService.RetrieveByEmailAsync(email));


    [HttpGet("by-property")]
    public async Task<IActionResult> GetByPropertyAsync(GetFilter filter)
        => Ok(await _userService.RetrieveByFilterAsync(filter));
}
