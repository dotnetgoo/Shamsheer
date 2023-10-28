using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.DTOs.Channels;
using Shamsheer.Service.Interfaces.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Channels;

public class ChannelsController : BaseController
{
    private readonly IChannelService _service;
    public ChannelsController(IChannelService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddChannelAsync([FromBody] ChannelForCreationDto dto) =>
        Ok(await this._service.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllChannelAsync() =>
        Ok(await this._service.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
        Ok(await this._service.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChannelAsync([FromRoute(Name = "id")] long id) =>
        Ok(await this._service.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateChannelAsync([FromRoute(Name = "id")] long id, [FromBody] ChannelForUpdateDto dto) =>
        Ok(await this._service.ModifyAsync(id, dto));
}
