using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Service.DTOs.Authorizations.Channels;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Extensions;

namespace Shamsheer.Service.Services.Authorizations.Channels;

public class ChannelRoleService : IChannelRoleService
{
    private readonly IMapper _mapper;
    private readonly IChannelRoleRepository _channelRoleRepository;

    public ChannelRoleService(IMapper mapper, IChannelRoleRepository channelRoleRepository)
    {
        this._mapper = mapper;
        this._channelRoleRepository = channelRoleRepository;
    }

    public async Task<ChannelRoleForResultDto> CreateAsync(ChatRole chatRole)
    {
        var channelRole = await this._channelRoleRepository.SelectAll()
            .Where(cr => cr.ChatRole == chatRole)
            .FirstOrDefaultAsync();

        if (channelRole is not null)
            throw new ShamsheerException(409, "ChannelRole is already exixts");

        var mappedChannelRole = new ChannelRole()
        {
            ChatRole = chatRole,
            CreatedAt = DateTime.UtcNow
        };
        var addedChannelRole = await this._channelRoleRepository.InsertAsync(mappedChannelRole);

        return this._mapper.Map<ChannelRoleForResultDto>(addedChannelRole);
    }

    public async Task<ChannelRoleForResultDto> ModifyAsync(long id, ChatRole chatRole)
    {
        var channelRole = await this._channelRoleRepository.SelectAll()
            .Where(gr => gr.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (channelRole is null)
            throw new ShamsheerException(404, "ChannelRole not found");

        var result = new ChannelRole()
        {
            Id = id,
            ChatRole = chatRole,
            UpdatedAt = DateTime.UtcNow
        };

        await this._channelRoleRepository.UpdateAsync(result);

        return this._mapper.Map<ChannelRoleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var channelRole = await this._channelRoleRepository.SelectAll()
            .Where(gr => gr.Id == id)
            .FirstOrDefaultAsync();
        if (channelRole is null)
            throw new ShamsheerException(404, "ChannelRole is not found");

        await this._channelRoleRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ChannelRoleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var channelRoles = await this._channelRoleRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this._mapper.Map<IEnumerable<ChannelRoleForResultDto>>(channelRoles);
    }

    public async Task<ChannelRoleForResultDto> RetrieveByIdAsync(long id)
    {
        var channelRole = await this._channelRoleRepository.SelectAll()
            .Where(gr => gr.Id == id)
            .FirstOrDefaultAsync();
        if (channelRole is null)
            throw new ShamsheerException(404, "ChannelRole is not found");

        return this._mapper.Map<ChannelRoleForResultDto>(channelRole);
    }
}
