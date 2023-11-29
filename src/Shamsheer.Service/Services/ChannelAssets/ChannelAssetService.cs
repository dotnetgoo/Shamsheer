using System;
using System.IO;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Helpers;
using System.Collections.Generic;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.ChannelAssets;
using Shamsheer.Service.Interfaces.ChannelAssets;

namespace Shamsheer.Service.Services.ChannelAssets;

public  class ChannelAssetService : IChannelAssetService
{
    private readonly IMapper _mapper;
    private readonly IChannelRepository _channelRepository;
    private readonly IChannelAssetRepository _channelAssetRepository;

    public ChannelAssetService(IMapper mapper,
                               IChannelRepository channelRepository,
                               IChannelAssetRepository channelAssetRepository)
    {
        _mapper = mapper;
        _channelRepository = channelRepository;
        _channelAssetRepository = channelAssetRepository;
    }



    public async Task<bool> RemoveAsync(long channelId, long id)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c => c.Id == channelId)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found");


        var channelAsset = await _channelRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (channelAsset is null)
            throw new ShamsheerException(404, "ChannelAsset is not found");


        await _channelAssetRepository.DeleteAsync(channelAsset.Id);

        return true;
    }

    public async Task<ChannelAssetForResultDto> CreateAsync(long channelId , IFormFile file)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c => c.Id == channelId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (channel is null)
        {
            throw new ShamsheerException(404, "Channel is not found");
        }


        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "ProfilePictures", "Channels", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new ChannelAsset()
        {
            ChannelId = channelId,
            Name = file.Name,
            Size = file.Length,
            Type = file.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(file.FileName),
            Path = Path.Combine("Media", "ProfilePictures", "Channels", file.FileName)
        };

        var result = await _channelAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<ChannelAssetForResultDto>(result);
    }

    public async Task<IEnumerable<ChannelAssetForResultDto>> RetriveAllAsync(long channelId, PaginationParams @params)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c => c.Id == channelId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found");

        var asset = await _channelAssetRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ChannelAssetForResultDto>>(asset);
    }

    public async Task<ChannelAssetForResultDto> RetriveByIdAsync(long channelId, long id)
    {
        var channel = await _channelRepository.SelectAll()
           .Where(c => c.Id == channelId)
           .AsNoTracking()
           .FirstOrDefaultAsync();

            if (channel is null)
                 throw new ShamsheerException(404, "Channel is not found");

            var channelAsset = await _channelAssetRepository.SelectAll()
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (channelAsset is null)
                throw new ShamsheerException(404, "ChannelAsset is not found");

            return _mapper.Map<ChannelAssetForResultDto>(channelAsset);
    }

   

}
