using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using Shamsheer.Service.DTOs.UserGroup;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using System.Xml.Linq;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Channels
{
    public class ChannelRolePermissionsController : BaseController
    {
        private readonly IChannelRolePermissionService _channelRolePermissionService;

        public ChannelRolePermissionsController(IChannelRolePermissionService channelRolePermissionService)
        {
            _channelRolePermissionService = channelRolePermissionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChannelRolePermissionForCreationDto dto)
            => Ok(await _channelRolePermissionService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _channelRolePermissionService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _channelRolePermissionService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChannelRolePermissionForUpdateDto dto)
            => Ok(await _channelRolePermissionService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _channelRolePermissionService.RemoveAsync(id));        
    }
}
