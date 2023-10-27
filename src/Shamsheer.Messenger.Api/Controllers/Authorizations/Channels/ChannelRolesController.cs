using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Authorizations.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Channels
{
    public class ChannelRolesController : BaseController
    {
        private readonly IChannelRoleService _channelRoleService;

        public ChannelRolesController(IChannelRoleService channelRoleService)
        {
            _channelRoleService = channelRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChatRole chatRole)
            => Ok(await _channelRoleService.CreateAsync(chatRole));

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _channelRoleService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _channelRoleService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChatRole chatRole)
            => Ok(await _channelRoleService.ModifyAsync(id, chatRole));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _channelRoleService.RemoveAsync(id));
    }
}
