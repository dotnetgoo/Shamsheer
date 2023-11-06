using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.ChannelAssets;

namespace Shamsheer.Service.Interfaces.ChannelAssets;

public  interface IChannelAssetService
{
    public Task<bool> RemoveAsync(long channelId, long id);
    public Task<ChannelAssetForResultDto> CreateAsync(long channelId , IFormFile file);
    public Task<ChannelAssetForResultDto> RetriveByIdAsync(long channelId, long id);
    public Task<IEnumerable<ChannelAssetForResultDto>> RetriveAllAsync(long channelId, PaginationParams @params);

}
