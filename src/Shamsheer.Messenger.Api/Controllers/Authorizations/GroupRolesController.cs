using Microsoft.AspNetCore.Mvc;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Service.Interfaces.Authorizations;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations;

public class GroupRolesController : BaseController
{
    private readonly IGroupRoleService groupRoleService;

    public GroupRolesController(IGroupRoleService groupRoleService)
    {
        this.groupRoleService = groupRoleService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ChatRole chatRole)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupRoleService.CreateAsync(chatRole)
        });

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupRoleService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupRoleService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChatRole chatRole)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupRoleService.ModifyAsync(id, chatRole)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupRoleService.RemoveAsync(id)
        });
}
