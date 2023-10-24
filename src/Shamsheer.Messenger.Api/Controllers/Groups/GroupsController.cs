using Microsoft.AspNetCore.Mvc;
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Interfaces.Groups;

namespace Shamsheer.Messenger.Api.Controllers.Groups
{
    public class GroupsController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GroupForCreationDto dto)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this._groupService.CreateAsync(dto)
        });

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this._groupService.RetrieveAllAsync(@params)
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this._groupService.RetrieveByIdAsync(id)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupForUpdateDto dto)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this._groupService.ModifyAsync(id, dto)
            });

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this._groupService.RemoveAsync(id)
            });

        
    }
}
