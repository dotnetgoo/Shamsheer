﻿using Microsoft.AspNetCore.Mvc;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.UserChannels;
using Shamsheer.Service.Interfaces.UserChannel;

namespace Shamsheer.Messenger.Api.Controllers.UserChannels;

public class UserChannelController : BaseController
{
    private readonly IUserChannelService _userChannelService;

    public UserChannelController(IUserChannelService userChannelService)
    {
        _userChannelService = userChannelService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserChannelForCreationDto dto)
    => Ok(await _userChannelService.CreateAsync(dto));

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userChannelService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userChannelService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserChannelForUpdateDto dto)
        => Ok(await _userChannelService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userChannelService.RemoveAsync(id));
}