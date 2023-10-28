using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Shamsheer.Service.Interfaces.UserAssets;

public interface IUserAssetService
{
    Task<bool> RemoveAsync(long userId, long id);
    Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id);
    Task<UserAssetForResultDto> CreateAsync(IFormFile formFile);
    Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params);
}