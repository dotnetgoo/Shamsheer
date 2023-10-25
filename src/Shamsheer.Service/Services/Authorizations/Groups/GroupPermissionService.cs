using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.Exceptions;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.Interfaces.Authorizations.Groups;

namespace Shamsheer.Service.Services.Authorizations.Groups;

public class GroupPermissionService : IGroupPermissionService
{
    private readonly IMapper _mapper;

    private readonly IGroupPermissionRepository _groupPermissionRepository;
    public GroupPermissionService(IMapper mapper, IGroupPermissionRepository groupPermissionRepository)
    {
        _mapper = mapper;
        _groupPermissionRepository = groupPermissionRepository;
    }

    public async Task<GroupPermissionForResultDto> CreateAsync(GroupPermissionType Type)
    {
        var groupPermission = await _groupPermissionRepository.SelectAll()
            .Where(gp => gp.Type == Type)
            .FirstOrDefaultAsync();
            
        if (groupPermission is not null)
            throw new ShamsheerException(409, "GroupPermission already exist");

        var mappedGroupPermission = new GroupPermission()
        {
            Type = Type,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await _groupPermissionRepository.InsertAsync(mappedGroupPermission);

        return _mapper.Map<GroupPermissionForResultDto>(result);
    }

    public async Task<GroupPermissionForResultDto> ModifyAsync(long id, GroupPermissionType Type)
    {
        var groupPermission = await _groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupPermission is null)
            throw new ShamsheerException(404, "groupPermission is not found");

        var mappedGroupPermission = new GroupPermission()
        {
            Id = id,
            Type = Type,
            UpdatedAt = DateTime.UtcNow,
        };
        var mapped = await _groupPermissionRepository.UpdateAsync(mappedGroupPermission);

        return _mapper.Map<GroupPermissionForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var groupPermission = await _groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupPermission is null)
            throw new ShamsheerException(404, "group permission is not found");

        await _groupPermissionRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<GroupPermissionForResultDto>> RetrieveAllAsync()
    {
        var groupPermissions = _groupPermissionRepository.SelectAll()
            .AsNoTracking();

        return _mapper.Map<IEnumerable<GroupPermissionForResultDto>>(groupPermissions);
    }

    public async Task<GroupPermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var groupPermission = await _groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == id)
            .FirstOrDefaultAsync();

        if (groupPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        return _mapper.Map<GroupPermissionForResultDto>(groupPermission);
    }
}
