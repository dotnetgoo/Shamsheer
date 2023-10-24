using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations.Channels;

public class ChannelPermissionService : IChannelPermissionService
{
    private readonly IMapper mapper;
    private readonly IChannelPermissionRepository _channelPermissionRepository;

    public ChannelPermissionService(IChannelPermissionRepository channelPermissionRepository, IMapper mapper)
    {
        this.mapper = mapper;
        this._channelPermissionRepository = channelPermissionRepository;
    }


    public async Task<ChannelPermissionForResultDto> CreateAsync(ChannelPermissionType type)
    {
        var channelPermission = await this._channelPermissionRepository.SelectAll()
            .Where(cp => cp.Type == type)
            .FirstOrDefaultAsync();
        if(channelPermission is not null)
            throw new ShamsheerException(409, "ChannelPermission already exist");

        var mappedChannelPermission = new ChannelPermission()
        {
            Type = type,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._channelPermissionRepository.InsertAsync(mappedChannelPermission);   

        return this.mapper.Map<ChannelPermissionForResultDto>(result);
    }

    public async Task<ChannelPermissionForResultDto> ModifyAsync(long id, ChannelPermissionType type)
    {
        var channelPermission = await this._channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        var mappedChannelPermission = new ChannelPermission()
        {
            Id = id,
            Type = type,
            UpdatedAt = DateTime.UtcNow,
        };
        var mapped = await this._channelPermissionRepository.UpdateAsync(mappedChannelPermission);

        return this.mapper.Map<ChannelPermissionForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var channelPermission = await this._channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        await this._channelPermissionRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ChannelPermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var channelPermissions = await this._channelPermissionRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<ChannelPermissionForResultDto>>(channelPermissions);
    }

    public async Task<ChannelPermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var channelPermission = await this._channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == id)
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        return this.mapper.Map<ChannelPermissionForResultDto>(channelPermission);
    }
}
