using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.ChannelAssets;

namespace Shamsheer.Service.Interfaces.ChannelAssets;

public  interface IChannelAssetService
{
    public Task<bool> RemoveAsync(long channelId, long id);
    public Task<ChannelAssetsForResultDto> CreateAsync(IFormFile file);
    public Task<ChannelAssetsForResultDto> RetriveByIdAsync(long channelId, long id);
    public Task<IEnumerable<ChannelAssetsForResultDto>> RetriveAllAsync(long channelId, PaginationParams @params);

}
