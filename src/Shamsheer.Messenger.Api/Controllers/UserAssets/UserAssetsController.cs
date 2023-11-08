using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.UserAssets;
using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Messenger.Api.Controllers.UserAssets;

public class UserAssetsController : BaseController
{
    private readonly IUserAssetService _userAssetService;

    public UserAssetsController(IUserAssetService userAssetService)
    {
       this._userAssetService = userAssetService;
    }

    [HttpPost("{user-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "user-id")] long userId, [Required] IFormFile formFile)
        => Ok(await this._userAssetService.CreateAsync(userId , formFile));

    [HttpGet("{user-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "user-id")] long userId)
        => Ok(await _userAssetService.RetrieveAllAsync(userId, @params));

    [HttpGet("{user-id}/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "user-id")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(await this._userAssetService.RetrieveByIdAsync(userId, id));

    [HttpDelete("{user-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "user-id")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(await this._userAssetService.RemoveAsync(userId, id));
}