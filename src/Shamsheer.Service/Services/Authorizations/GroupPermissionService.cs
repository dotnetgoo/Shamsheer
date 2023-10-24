using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.Authorizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations;

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
        var groupPermission = await this._groupPermissionRepository.SelectAll()
            .Where(gp => gp.Type == Type)
            .FirstOrDefaultAsync();
        if (groupPermission is not null)
            throw new ShamsheerException(409, "GroupPermission already exist");

        var mappedGroupPermission = new GroupPermission()
        {
            Type = Type,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._groupPermissionRepository.InsertAsync(mappedGroupPermission);

        return this._mapper.Map<GroupPermissionForResultDto>(result);
    }

    public async Task<GroupPermissionForResultDto> ModifyAsync(long id, GroupPermissionType Type)
    {
        var groupPermission = await this._groupPermissionRepository.SelectAll()
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
        var mapped = await this._groupPermissionRepository.UpdateAsync(mappedGroupPermission);

        return this._mapper.Map<GroupPermissionForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var groupPermission = await this._groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupPermission is null)
            throw new ShamsheerException(404, "group permission is not found");

        await this._groupPermissionRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<GroupPermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var groupPermissions = await this._groupPermissionRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this._mapper.Map<IEnumerable<GroupPermissionForResultDto>>(groupPermissions);
    }

    public async Task<GroupPermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var groupPermission = await this._groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == id)
            .FirstOrDefaultAsync();
            
        if (groupPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        return this._mapper.Map<GroupPermissionForResultDto>(groupPermission);
    }
}
