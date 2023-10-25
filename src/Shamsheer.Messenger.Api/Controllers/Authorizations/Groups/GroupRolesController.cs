using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Interfaces.Authorizations;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Groups;

public class GroupRolesController : BaseController
{
    private readonly IGroupRoleService _groupRoleService;

    public GroupRolesController(IGroupRoleService groupRoleService)
    {
        _groupRoleService = groupRoleService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ChatRole chatRole)
        => Ok(await _groupRoleService.CreateAsync(chatRole));

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _groupRoleService.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _groupRoleService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChatRole chatRole)
        => Ok(await _groupRoleService.ModifyAsync(id, chatRole));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _groupRoleService.RemoveAsync(id));
}
