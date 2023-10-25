using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Service.Interfaces.Authorizations.Groups;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Groups;

public class GroupPermissionsController : BaseController
{

    private readonly IGroupPermissionService _groupPermissionService;

    public GroupPermissionsController(IGroupPermissionService groupPermissionService)
    {
        _groupPermissionService = groupPermissionService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] GroupPermissionType type)
        => Ok(await _groupPermissionService.CreateAsync(type));

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _groupPermissionService.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _groupPermissionService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupPermissionType type)
        => Ok(await _groupPermissionService.ModifyAsync(id, type));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _groupPermissionService.RemoveAsync(id));
}
