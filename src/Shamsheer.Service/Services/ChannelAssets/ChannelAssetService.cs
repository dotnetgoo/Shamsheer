using System;
using System.IO;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamsheer.Service.Helpers;
using System.Collections.Generic;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.ChannelAssets;
using Shamsheer.Service.Interfaces.ChannelAssets;

namespace Shamsheer.Service.Services.ChannelAssets;

public  class ChannelAssetService : IChannelAssetService
{

    IMapper _mapper;
    IChannelRepository _channelRepository;
    IChannelAssetRepository _channelAssetRepository;

    public ChannelAssetService(IMapper mapper,
                               IChannelRepository channelRepository, 
                               IChannelAssetRepository  channelAssetRepository)
    {
        _mapper = mapper;
        _channelRepository = channelRepository;
        _channelAssetRepository = channelAssetRepository;
    }

   

    public async Task<bool>RemoveAsync(long channelId , long id)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c=>c.Id == channelId)
            .FirstOrDefaultAsync();

        if(channel == null)
            throw new ShamsheerException(404, "Channel is not found");
        

        var channelAsste = await _channelRepository.SelectAll()
            .Where(c=>c.Id == id)
            .FirstOrDefaultAsync();

        if(channelAsste == null)
            throw new ShamsheerException(404, "Channel is not found");
       

        await _channelAssetRepository.DeleteAsync(channelId);

        return true;
    }

    public async Task<ChannelAssetsForResultDto> CreateAsync(IFormFile file)
    {
        //TODO:LOGIC
        long channelId = 1; //<= jwt token
        var channel = await _channelRepository.SelectAll()
            .Where(x=>x.Id == channelId)
            .FirstOrDefaultAsync();
        if (channel == null)
        {
            throw new ShamsheerException(404, "Channel is not found");
        }
        

        var fileName = Guid.NewGuid().ToString("N")+Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "ProfilePictures", "Channels", fileName);

        using (var stream = new FileStream(rootPath,FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream .FlushAsync();
            stream .Close();
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

        return  _mapper.Map<ChannelAssetsForResultDto>(result);
    }

    public async Task<IEnumerable<ChannelAssetsForResultDto>>RetriveAllAsync(long channelId , PaginationParams  @params)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c=> c.Id == channelId)
            .FirstOrDefaultAsync();

        if (channel == null)
            throw new ShamsheerException(404, "Channel is not found");

        var asset = await _channelAssetRepository.SelectAll()
            .ToPagedList(@params)
            .ToListAsync();

        return  _mapper.Map<IEnumerable<ChannelAssetsForResultDto>>(asset);
    }

    public async Task<ChannelAssetsForResultDto>RetriveByIdAsync(long channelId , long id )
    {
        var channel = await _channelRepository.SelectAll()
            .Where(c=>c.Id==channelId)
            .FirstOrDefaultAsync();

        if (channel == null)
            throw new ShamsheerException(404, "Channel is not found");


        var channelAsset = await _channelAssetRepository.SelectAll()
            .Where(c=>c.Id == id)
            .FirstOrDefaultAsync();

        if (channelAsset == null)
            throw new ShamsheerException(404, "Channel is not found");

        return _mapper.Map<ChannelAssetsForResultDto>(channelAsset);
    }
   



}
