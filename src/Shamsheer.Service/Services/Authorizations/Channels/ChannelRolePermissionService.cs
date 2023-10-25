using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations.Channels;

public class ChannelRolePermissionService : IChannelRolePermissionService
{
    private readonly IMapper _mapper;
    private readonly IChannelRoleRepository _channelRoleRepository;
    private readonly IChannelPermissionRepository _channelPermissionRepository;
    private readonly IChannelRolePermissionRepository _channelRolePermissionRepository;

    public ChannelRolePermissionService(
        IMapper mapper,
        IChannelRoleRepository channelRoleRepository,
        IChannelPermissionRepository channelPermissionRepository,
        IChannelRolePermissionRepository channelRolePermissionRepository)
    {
        this._mapper = mapper;
        this._channelRoleRepository = channelRoleRepository;
        this._channelPermissionRepository = channelPermissionRepository;    
        this._channelRolePermissionRepository = channelRolePermissionRepository;
    }

    public async Task<ChannelRolePermissionForResultDto> CreateAsync(ChannelRolePermissionForCreationDto dto)
    {
        var channelRole = await _channelRoleRepository.SelectAll()
            .Where(cr => cr.Id == dto.RoleId)
            .FirstOrDefaultAsync();
        if (channelRole is null)
            throw new ShamsheerException(404, "ChannelRole is not found");

        var channelPermission = await _channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == dto.PermissionId)
            .FirstOrDefaultAsync();
        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        var mappedChannelRolePermission = _mapper.Map<ChannelRolePermission>(dto);
        mappedChannelRolePermission.CreatedAt = DateTime.UtcNow;

        var result = await _channelRolePermissionRepository.InsertAsync(mappedChannelRolePermission);

        return _mapper.Map<ChannelRolePermissionForResultDto>(result);
        
    }

    public async Task<ChannelRolePermissionForResultDto> ModifyAsync(long id, ChannelRolePermissionForUpdateDto dto)
    {
        var channelRolePermission = await _channelRolePermissionRepository.SelectAll()
            .Where(crp => crp.Id == id)
            .FirstOrDefaultAsync();
        if (channelRolePermission is null)
            throw new ShamsheerException(404, "ChannelRolePermission is not found");

        var channelRole = await _channelRoleRepository.SelectAll()
            .Where(cr => cr.Id == dto.RoleId)
            .FirstOrDefaultAsync();
        if (channelRole is null)
            throw new ShamsheerException(404, "ChannelRole is not found");

        var channelPermission = await _channelPermissionRepository.SelectAll()
            .Where(cp => cp.Id == dto.PermissionId)
            .FirstOrDefaultAsync();
        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        var mappedChannelRolePermission = _mapper.Map(dto, channelRolePermission);
        mappedChannelRolePermission.UpdatedAt = DateTime.UtcNow;

        await _channelRolePermissionRepository.UpdateAsync(mappedChannelRolePermission);

        return _mapper.Map<ChannelRolePermissionForResultDto>(mappedChannelRolePermission);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var channelRolePermission = await _channelRolePermissionRepository.SelectAll()
            .Where(crp => crp.Id == id)
            .FirstOrDefaultAsync();
        if (channelRolePermission is null)
            throw new ShamsheerException(404, "ChannelRolePermission is not found");

        return await _channelRolePermissionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ChannelRolePermissionForResultDto>> RetrieveAllAsync()
    {
        var channelRolePermission = _channelRolePermissionRepository.SelectAll()
            .Include(crp => crp.Role)
            .Include(crp => crp.Permission)
            .AsNoTracking();

        return _mapper.Map<IEnumerable<ChannelRolePermissionForResultDto>>(channelRolePermission);
    }

    public async Task<ChannelRolePermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var channelRolePermission = await _channelRolePermissionRepository.SelectAll()
            .Where(crp => crp.Id == id)
            .Include(crp => crp.Role)
            .Include(crp => crp.Permission)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelRolePermission is null)
            throw new ShamsheerException(404, "ChannelRolePermission is not found");

        return _mapper.Map<ChannelRolePermissionForResultDto>(channelRolePermission);
    }
}
