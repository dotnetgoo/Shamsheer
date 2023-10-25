using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.Authorizations.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations.Groups;

public class GroupRolePermissionService : IGroupRolePermissionService
{
    private readonly IMapper _mapper;
    private readonly IGroupRoleRepository _groupRoleRepository;
    private readonly IGroupPermissionRepository _groupPermissionRepository;
    private readonly IGroupRolePermissionRepository _groupRolePermissionRepository;

    public GroupRolePermissionService(
        IMapper mapper,
        IGroupRoleRepository groupRoleRepository,
        IGroupPermissionRepository groupPermissionRepository,
        IGroupRolePermissionRepository groupRolePermissionRepository)
    {
        this._mapper = mapper;
        this._groupRoleRepository = groupRoleRepository;
        this._groupPermissionRepository = groupPermissionRepository;
        this._groupRolePermissionRepository = groupRolePermissionRepository;
    }

    public async Task<GroupRolePermissionForResultDto> CreateAsync(GroupRolePermissionForCreationDto dto)
    {
        var groupRole = await _groupRoleRepository.SelectAll()
            .Where(gr => gr.Id == dto.RoleId)
            .FirstOrDefaultAsync();

        if (groupRole is null)
            throw new ShamsheerException(404, "GroupRole is not found");

        var groupPermission = await _groupPermissionRepository.SelectAll() 
            .Where(gp => gp.Id == dto.PermissionId)
            .FirstOrDefaultAsync();

        if (groupPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        var mappedGroupRolePermission = _mapper.Map<GroupRolePermission>(dto);
        mappedGroupRolePermission.CreatedAt = DateTime.UtcNow;

        var result = await _groupRolePermissionRepository.InsertAsync(mappedGroupRolePermission);

        return _mapper.Map<GroupRolePermissionForResultDto>(result);
        
    }

    public async Task<GroupRolePermissionForResultDto> ModifyAsync(long id, GroupRolePermissionForUpdateDto dto)
    {
        var groupRolePermission = await _groupRolePermissionRepository.SelectAll()
            .Where(grp => grp.Id == id)
            .FirstOrDefaultAsync();
        if (groupRolePermission is null)
            throw new ShamsheerException(404, "GroupRolePermission is not found");

        var groupRole = await _groupRoleRepository.SelectAll()
            .Where(gr => gr.Id == dto.RoleId)
            .FirstOrDefaultAsync();
        if (groupRole is null)
            throw new ShamsheerException(404, "GroupRole is not found");

        var groupPermission = await _groupPermissionRepository.SelectAll()
            .Where(gp => gp.Id == dto.PermissionId)
            .FirstOrDefaultAsync();
        if (groupPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        var mappedGroupRolePermission = _mapper.Map(dto, groupRolePermission);
        mappedGroupRolePermission.UpdatedAt = DateTime.UtcNow;

        await _groupRolePermissionRepository.UpdateAsync(mappedGroupRolePermission);

        return _mapper.Map<GroupRolePermissionForResultDto>(mappedGroupRolePermission);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var groupRolePermission = await _groupRolePermissionRepository.SelectAll()
            .Where(grp => grp.Id == id)
            .FirstOrDefaultAsync();

        if (groupRolePermission is null)
            throw new ShamsheerException(404, "GroupRolePermission is not found");


        return await _groupRolePermissionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<GroupRolePermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var groupRolePermission = await _groupRolePermissionRepository.SelectAll()
            .Include(grp => grp.Permission)
            .Include(grp => grp.Role)
            .ToPagedList(@params)
            .ToListAsync();
        

        return _mapper.Map<IEnumerable<GroupRolePermissionForResultDto>>(groupRolePermission);
    }

    public async Task<GroupRolePermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var groupRolePermission = await _groupRolePermissionRepository.SelectAll()
            .Where(grp => grp.Id == id)
            .Include(grp => grp.Permission)
            .Include(grp => grp.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupRolePermission is null)
            throw new ShamsheerException(404, "GroupRolePermsission is not found");

        return _mapper.Map<GroupRolePermissionForResultDto>(groupRolePermission);
    }
}
