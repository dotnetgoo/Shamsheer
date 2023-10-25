using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Groups;
=======
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
using Shamsheer.Service.DTOs.UserGroup;
using Shamsheer.Service.Interfaces.UserGroup;

namespace Shamsheer.Messenger.Api.Controllers.UserGroups;

public class UserGroupsController : BaseController
{
    private readonly IUserGroupService _userGroupService;

    public UserGroupsController(IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserGroupForCreationDto dto)
    => Ok(await _userGroupService.CreateAsync(dto));

    [HttpGet()]
<<<<<<< HEAD
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this._userGroupService.RetrieveAllAsync(@params)
        });
=======
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _userGroupService.RetrieveAllAsync());
>>>>>>> f547e2782442944ef96045807bcde6a4041df003

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userGroupService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserGroupForUpdateDto dto)
        => Ok(await _userGroupService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userGroupService.RemoveAsync(id));


}

