using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.GroupAssets;

namespace Shamsheer.Messenger.Api.Controllers.GroupAssets;

public class GroupAssetsController : BaseController
{
    private readonly IGroupAssetService _groupAssetService;

    public GroupAssetsController(IGroupAssetService groupAssetService)
    {
        _groupAssetService = groupAssetService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(IFormFile formFile)
        => Ok(await _groupAssetService.CreateAsync(formFile));

    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute] long groupId)
        => Ok(await _groupAssetService.RetrieveAllAsync(groupId, @params));

    [HttpGet("{groupId} {id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "groupId")] long groupId, [FromRoute(Name = "id")] long id)
        => Ok(await _groupAssetService.RetrieveByIdAsync(groupId, id));



    [HttpDelete("{groupId} {id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "groupId")] long groupId, [FromRoute(Name = "id")] long id)
        => Ok(await _groupAssetService.RemoveAsync(groupId, id));
}