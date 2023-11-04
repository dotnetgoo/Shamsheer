using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.ChannelAssets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shamsheer.Service.Interfaces.ChannelAssets;

public  interface IChannelAssetService
{
    public Task<bool> RemoveAsync(long channelId, long id);
    public Task<ChannelAssetForResultDto> CreateAsync(IFormFile file);
    public Task<ChannelAssetForResultDto> RetriveByIdAsync(long channelId, long id);
    public Task<IEnumerable<ChannelAssetForResultDto>> RetriveAllAsync(long channelId, PaginationParams @params);




}
