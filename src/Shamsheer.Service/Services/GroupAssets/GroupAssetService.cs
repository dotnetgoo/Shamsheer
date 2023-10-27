using System;
using System.IO;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Shamsheer.Service.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.GroupAssets;
using Shamsheer.Service.Interfaces.GroupAssets;

namespace Shamsheer.Service.Services.GroupAssets;

public class GroupAssetService : IGroupAssetService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IGroupAssetRepository _groupAssetRepository;

    public GroupAssetService(IMapper mapper, IGroupRepository groupRepository, IGroupAssetRepository groupAssetRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _groupAssetRepository = groupAssetRepository;
    }
    public async Task<GroupAssetForResultDto> CreateAsync(IFormFile formFile)
    {
        //Identify GroupId TODO:LOGIC
        long groupId = 1; //Actually this one is takes from jwt token, now we need to give default value
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == groupId)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "ProfilePictures", "Groups", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new GroupAsset()
        {
            GroupId = groupId,
            Name = fileName,
            Path = Path.Combine("Media", "ProfilePictures", "Groups", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _groupAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<GroupAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long groupId, long id)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == groupId)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var groupAsset = await _groupAssetRepository.SelectAll()
            .Where(ga => ga.Id == id)
            .FirstOrDefaultAsync();
        if (groupAsset is null)
            throw new ShamsheerException(404, "Group Asset is not found.");

        await _groupAssetRepository.DeleteAsync(groupAsset.Id);

        return true;
    }

    public async Task<IEnumerable<GroupAssetForResultDto>> RetrieveAllAsync(long groupId, PaginationParams @params)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == groupId)
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var assets = await _groupAssetRepository.SelectAll()
                .ToPagedList(@params)
                .ToListAsync();

        return _mapper.Map<IEnumerable<GroupAssetForResultDto>>(assets);
    }

    public async Task<GroupAssetForResultDto> RetrieveByIdAsync(long groupId, long id)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == groupId)
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var groupAsset = await _groupAssetRepository.SelectAll()
            .Where(ga => ga.Id == id)
            .FirstOrDefaultAsync();

        if (groupAsset is null)
            throw new ShamsheerException(404, "Group Asset is not found.");

        var mappedAsset = _mapper.Map<GroupAssetForResultDto>(groupAsset);

        return mappedAsset;
    }
}