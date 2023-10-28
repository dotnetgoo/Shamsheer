using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.Helpers;
using Shamsheer.Service.Interfaces.UserAssets;

namespace Shamsheer.Messenger.Api.Controllers.UserAssets;

public class UserAssetsController : BaseController
{
    private readonly IUserAssetService _userAssetService;
    private readonly WebHostEnviromentHelper _webHostEnviromentHelper;

    public UserAssetsController(IUserAssetService userAssetService)
    {
       this._userAssetService = userAssetService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(IFormFile formFile)
        => Ok(await this._userAssetService.CreateAsync(formFile));

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "userId")] long userId)
        => Ok(await this._userAssetService.RetrieveAllAsync(userId, @params));

    [HttpGet("{userId},{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "userId")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(await this._userAssetService.RetrieveByIdAsync(userId, id));

    [HttpDelete("{userId},{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "userId")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(await this._userAssetService.RemoveAsync(userId, id));
}