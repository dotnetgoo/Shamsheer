﻿using Microsoft.AspNetCore.Mvc;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.DTOs.Channels;
using Shamsheer.Service.Interfaces.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Channels
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _service;
        public ChannelController(IChannelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddChannelAsync([FromBody] ChannelForCreationDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _service.AddAsync(dto)
            });

        [HttpGet]
        public async Task<IActionResult> GetAllChannelAsync() =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _service.RetrieveAllAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _service.RetrieveByIdAsync(id)
            });

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannelAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _service.RemoveAsync(id)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChannelAsync([FromRoute(Name = "id")] long id, [FromBody] ChannelForUpdateDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _service.ModifyAsync(id, dto)
            });
    }
}