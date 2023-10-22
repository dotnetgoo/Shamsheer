﻿using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.DTOs.UserAssets;
using Shamsheer.Service.Interfaces.UserAssets;

namespace Shamsheer.Service.Services.UserAssets;

public class UserAssetService : IUserAssetService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserAssetRepository _userAssetRepository;

    public UserAssetService(IMapper mapper, IUserRepository userRepository, IUserAssetRepository userAssetRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userAssetRepository = userAssetRepository;
    }
    public async Task<UserAssetForResultDto> CreateAsync(UserAssetForCreationDto dto)
    {
        //Identify UserId TODO:LOGIC
        long userId = 0; //Default qiymat berib turildi, aslida jwt tokendan yechib olinadi
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var mappedAsset = _mapper.Map<UserAsset>(dto);
        mappedAsset.UserId = userId;
        mappedAsset.CreatedAt = DateTime.UtcNow;
        var result = await _userAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<UserAssetForResultDto>(result);
    }  

    public async Task<bool> RemoveAsync(long id)
    {
        var userAsset = await _userAssetRepository.SelectAll()
            .Where(ur => ur.Id == id)
            .FirstOrDefaultAsync();

        if (userAsset is null)
            throw new ShamsheerException(404, "User Asset is not found.");

        await _userAssetRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId)
    {
        //TODO:LOGIC pagination logic
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var mappedAssets = _mapper.Map<IEnumerable<UserAssetForResultDto>>(user.Assets);

        return mappedAssets;
    }

    public async Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var asset = await _userAssetRepository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (asset is null)
            throw new ShamsheerException(404, "User Asset is not found.");

        var mappedAsset = _mapper.Map<UserAssetForResultDto>(asset);

        return mappedAsset;
    }
}
