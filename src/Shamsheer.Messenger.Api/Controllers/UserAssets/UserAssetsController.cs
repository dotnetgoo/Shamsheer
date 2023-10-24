using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.Interfaces.UserAssets;

namespace Shamsheer.Messenger.Api.Controllers.UserAssets;

public class UserAssetsController : BaseController
{
    private readonly IUserAssetService _userAssetService;

    public UserAssetsController(IUserAssetService userAssetService)
    {
        _userAssetService = userAssetService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserAssetForCreationDto dto)
        => Ok(await _userAssetService.CreateAsync(dto));

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "userId")] long userId)
        => Ok(await _userAssetService.RetrieveAllAsync(userId, @params));

    [HttpGet("{userId},{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "userId")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(await _userAssetService.RetrieveByIdAsync(userId, id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userAssetService.RemoveAsync(id));
}