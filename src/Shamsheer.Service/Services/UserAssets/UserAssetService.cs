using System;
using System.IO;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Helpers;
using System.Collections.Generic;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Service.Configurations;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.Interfaces.UserAssets;

namespace Shamsheer.Service.Services.UserAssets;

public class UserAssetService : IUserAssetService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserAssetRepository _userAssetRepository;

    public UserAssetService(IMapper mapper, IUserRepository userRepository, IUserAssetRepository userAssetRepository, WebHostEnviromentHelper webHostEnvironment)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userAssetRepository = userAssetRepository;
    }
    public async Task<UserAssetForResultDto> CreateAsync(IFormFile formFile)
    {
        //Identify UserId TODO:LOGIC
        long userId = 1; //Actually this one is takes from jwt token, now we need to give default value
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "ProfilePictures", "Users", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new UserAsset()
        {
            UserId = userId,
            Name = fileName,
            Path = Path.Combine("Media", "ProfilePictures", "Users", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<UserAssetForResultDto>(result);
    }  

    public async Task<bool> RemoveAsync(long userId, long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var userAsset = await _userAssetRepository.SelectAll()
            .Where(ur => ur.Id == id)
            .FirstOrDefaultAsync();
        if (userAsset is null)
            throw new ShamsheerException(404, "User Asset is not found.");


        await _userAssetRepository.DeleteAsync(userAsset.Id);

        return true;
    }

    public async Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params)
    {
        //TODO:LOGIC pagination logic
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");
        var assets = await _userAssetRepository.SelectAll()
                .ToPagedList(@params)
                .ToListAsync();

        return _mapper.Map<IEnumerable<UserAssetForResultDto>>(assets);
    }

    public async Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var userAsset = await _userAssetRepository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (userAsset is null)
            throw new ShamsheerException(404, "User Asset is not found.");

        var mappedAsset = _mapper.Map<UserAssetForResultDto>(userAsset);

        return mappedAsset;
    }
}
