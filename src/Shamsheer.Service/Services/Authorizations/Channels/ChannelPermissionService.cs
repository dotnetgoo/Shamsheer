using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations.Channels;

public class ChannelPermissionService : IChannelPermissionService
{
    private readonly IMapper mapper;
    private readonly IChannelPermissionRepository channelPermissionRepository;

    public ChannelPermissionService(IChannelPermissionRepository channelPermissionRepository, IMapper mapper)
    {
        this.mapper = mapper;
        this.channelPermissionRepository = channelPermissionRepository;
    }


    public async Task<ChannelPermissionForResultDto> CreateAsync(ChannelPermissionType type)
    {
        var channelPermission = await this.channelPermissionRepository.SelectAll()
            .Where(cp => cp.Type == type)
            .FirstOrDefaultAsync();
        if(channelPermission is not null)
            throw new ShamsheerException(409, "ChannelPermission already exist");

        var mappedChannelPermission = new ChannelPermission()
        {
            Type = type,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this.channelPermissionRepository.InsertAsync(mappedChannelPermission);   

        return this.mapper.Map<ChannelPermissionForResultDto>(result);
    }

    public async Task<ChannelPermissionForResultDto> ModifyAsync(long id, ChannelPermissionType type)
    {
        var channelPermission = await this.channelPermissionRepository.SelectAll()
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
        var mapped = await this.channelPermissionRepository.UpdateAsync(mappedChannelPermission);

        return this.mapper.Map<ChannelPermissionForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var channelPermission = await this.channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        await this.channelPermissionRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ChannelPermissionForResultDto>> RetrieveAllAsync()
    {
        var channelPermission = this.channelPermissionRepository.SelectAll()
            .AsNoTracking();

        return this.mapper.Map<IEnumerable<ChannelPermissionForResultDto>>(channelPermission);
    }

    public async Task<ChannelPermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var channelPermission = await this.channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == id)
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        return this.mapper.Map<ChannelPermissionForResultDto>(channelPermission);
    }
}
