using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.ChannelAssets;

namespace Shamsheer.Messenger.Api.Controllers.ChannelAssets;

[Route("api/[controller]")]
[ApiController]
public class ChannelAssetsController : ControllerBase
{
    IChannelAssetService _channelAssetService;

    public ChannelAssetsController(IChannelAssetService channelAssetService)
    {
        _channelAssetService = channelAssetService;
    }


    [HttpPost]
    public async Task<IActionResult>PostAsync(IFormFile file)
        =>Ok( await _channelAssetService.CreateAsync(file));


    [HttpGet("{channelId}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute] long channelId)
        => Ok(await  _channelAssetService.RetriveAllAsync(channelId,@params));


    [HttpGet("{channelId} {id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name ="channelId")] long channelId, [FromRoute(Name = "id")] long id)
        =>Ok(await _channelAssetService.RetriveByIdAsync(channelId , id));




    [HttpDelete("{channelId} {id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "channelId")] long channelId, [FromRoute(Name = "id")] long id)
        =>Ok(await _channelAssetService.RemoveAsync(channelId , id));



}
