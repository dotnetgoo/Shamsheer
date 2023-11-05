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


        [HttpPost("{channel-id}")]
        public async Task<IActionResult> PostAsync(IFormFile file,[FromRoute(Name = "channel-id")] long channelId)
            => Ok(await _channelAssetService.CreateAsync(file , channelId));


        [HttpGet("{channel-id}")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "channel-id")] long channelId)
        => Ok(await _channelAssetService.RetriveAllAsync(channelId, @params));


        [HttpGet("{channel-id}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "channel-id")] long channelId, [FromRoute(Name = "id")] long id)
        => Ok(await _channelAssetService.RetriveByIdAsync(channelId, id));




        [HttpDelete("{channel-id}/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "channel-id")] long channelId, [FromRoute(Name = "id")] long id)
            => Ok(await _channelAssetService.RemoveAsync(channelId, id));
    }
}
