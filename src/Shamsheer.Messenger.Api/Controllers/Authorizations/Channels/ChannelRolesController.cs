using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Service.Interfaces.Authorizations.Channels;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Channels
{
    public class ChannelRolesController : BaseController
    {
        private readonly IChannelRoleService channelRoleService;

        public ChannelRolesController(IChannelRoleService channelRoleService)
        {
            this.channelRoleService = channelRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChatRole chatRole)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.channelRoleService.CreateAsync(chatRole)
            });

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.channelRoleService.RetrieveAllAsync(@params)
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.channelRoleService.RetrieveByIdAsync(id)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ChatRole chatRole)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.channelRoleService.ModifyAsync(id, chatRole)
            });

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.channelRoleService.RemoveAsync(id)
            });
    }
}
