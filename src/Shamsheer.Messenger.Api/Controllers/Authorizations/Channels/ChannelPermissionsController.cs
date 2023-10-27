using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Authorizations.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Channels;

public class ChannelPermissionsController : BaseController
{
    private readonly IChannelPermissionService _channelPermissionService;

    public ChannelPermissionsController(IChannelPermissionService channelPermissionService)
    {
        _channelPermissionService = channelPermissionService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ChannelPermissionType type)
        => Ok(await _channelPermissionService.CreateAsync(type));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _channelPermissionService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _channelPermissionService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChannelPermissionType type)
        => Ok(await _channelPermissionService.ModifyAsync(id, type));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _channelPermissionService.RemoveAsync(id));
}
