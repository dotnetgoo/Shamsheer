using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;
using Shamsheer.Service.Interfaces.Authorizations.Groups;

namespace Shamsheer.Messenger.Api.Controllers.Authorizations.Groops
{
    public class GroupRolePermissionsController : BaseController
    {
        private readonly IGroupRolePermissionService _groupRolePermissionService;

        public GroupRolePermissionsController(IGroupRolePermissionService groupRolePermissionService)
        {
            _groupRolePermissionService = groupRolePermissionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GroupRolePermissionForCreationDto dto)
            => Ok(await _groupRolePermissionService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _groupRolePermissionService.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _groupRolePermissionService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupRolePermissionForUpdateDto dto)
            => Ok(await _groupRolePermissionService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _groupRolePermissionService.RemoveAsync(id));


    }
}
