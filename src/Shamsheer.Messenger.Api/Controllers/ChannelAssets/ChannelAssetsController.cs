using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Interfaces.ChannelAssets;

namespace Shamsheer.Messenger.Api.Controllers.ChannelAssets
{
    public class ChannelAssetsController : BaseController
    {
        private readonly IChannelAssetService _channelAssetService;

        public ChannelAssetsController(IChannelAssetService channelAssetService)
        {
            _channelAssetService = channelAssetService;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormFile file)
            => Ok(await _channelAssetService.CreateAsync(file));


        [HttpGet("{channel-id}")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute] long channelId)
        => Ok(await _channelAssetService.RetriveAllAsync(channelId, @params));


        [HttpGet("{channel-id}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "channelId")] long channelId, [FromRoute(Name = "id")] long id)
        => Ok(await _channelAssetService.RetriveByIdAsync(channelId, id));




        [HttpDelete("{channel-id}/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "channelId")] long channelId, [FromRoute(Name = "id")] long id)
            => Ok(await _channelAssetService.RemoveAsync(channelId, id));
    }
}
