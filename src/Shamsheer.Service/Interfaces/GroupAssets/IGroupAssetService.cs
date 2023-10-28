using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.GroupAssets;

namespace Shamsheer.Service.Interfaces.GroupAssets;

public interface IGroupAssetService
{
    Task<bool> RemoveAsync(long groupId, long id);
    Task<GroupAssetForResultDto> CreateAsync(IFormFile formFile);
    Task<GroupAssetForResultDto> RetrieveByIdAsync(long groupId, long id);
    Task<IEnumerable<GroupAssetForResultDto>> RetrieveAllAsync(long groupId, PaginationParams @params);
}