using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Interfaces.Authorizations.Groups;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Groops;

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
            Data = await groupPermissionService.CreateAsync(type)
        });

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await groupPermissionService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await groupPermissionService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupPermissionType type)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await groupPermissionService.ModifyAsync(id, type)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await groupPermissionService.RemoveAsync(id)
        });
}
