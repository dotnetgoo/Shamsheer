using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Service.Interfaces.Authorizations.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Channels;

public class ChannelPermissionsController : BaseController
{
    private readonly IChannelPermissionService channelPermissionService;

    public ChannelPermissionsController(IChannelPermissionService channelPermissionService)
    {
        this.channelPermissionService = channelPermissionService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ChannelPermissionType type)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.channelPermissionService.CreateAsync(type)
        });

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.channelPermissionService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.channelPermissionService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChannelPermissionType type)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.channelPermissionService.ModifyAsync(id, type)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this.channelPermissionService.RemoveAsync(id)
        });
}
