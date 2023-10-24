using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Authorizations;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations;

public class GroupPermissionsController : BaseController
{

    private readonly IGroupPermissionService groupPermissionService;

    public GroupPermissionsController(IGroupPermissionService groupPermissionService)
    {
        this.groupPermissionService = groupPermissionService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] GroupPermissionType type)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupPermissionService.CreateAsync(type)
        });

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupPermissionService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupPermissionService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupPermissionType type)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupPermissionService.ModifyAsync(id, type)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.groupPermissionService.RemoveAsync(id)
        });
}
