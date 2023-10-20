using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Service.DTOs.Authorizations.Groups;
using Shamsheer.Domain.Entities.Authorizations.Groups;

namespace Shamsheer.Service.Services.Authorizations;

public class GroupRoleService : IGroupRoleService
{
    private readonly IMapper _mapper;
    private readonly IGroupRoleRepository _groupRoleRepository;

    public GroupRoleService(IMapper mapper, IGroupRoleRepository groupRoleRepository)
    {
        _mapper = mapper;
        _groupRoleRepository = groupRoleRepository;
    }

    public async Task<GroupRoleForResultDto> CreateAsync(ChatRole chatRole)
    {
        var groupRole = await this._groupRoleRepository.SelectAll()
            .Where(gr => gr.ChatRole == chatRole)
            .FirstOrDefaultAsync();

        if (groupRole is not null)
            throw new ShamsheerException(409, "grouprole is already exixts");
        
        var mappedGroupRole = new GroupRole()
        {
            ChatRole = chatRole,
            CreatedAt = DateTime.UtcNow
        };
        var addedGroupRole = await this._groupRoleRepository.InsertAsync(mappedGroupRole);

        return  this._mapper.Map<GroupRoleForResultDto>(addedGroupRole);
    }

    public async Task<GroupRoleForResultDto> ModifyAsync(long id, ChatRole chatRole)
    {
        var groupRole = await this._groupRoleRepository.SelectAll()
            .Where(gr => gr.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (groupRole is null)
            throw new ShamsheerException(404, "GroupRole not found");

        var result = new GroupRole()
        {
            Id = id,
            ChatRole = chatRole,
            UpdatedAt = DateTime.UtcNow
        };

        await this._groupRoleRepository.UpdateAsync(result);

        return this._mapper.Map<GroupRoleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var groupRole = await this._groupRoleRepository.SelectAll()
            .Where (gr => gr.Id == id)
            .FirstOrDefaultAsync();
        if (groupRole is null)
            throw new ShamsheerException(404, "GroupRole is not found");

        await this._groupRoleRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<GroupRoleForResultDto>> RetrieveAllAsync()
    {
        var groupRoles =  this._groupRoleRepository.SelectAll()
            .AsNoTracking();

        return this._mapper.Map<IEnumerable<GroupRoleForResultDto>>(groupRoles);
    }

    public async Task<GroupRoleForResultDto> RetrieveByIdAsync(long id)
    {
        var groupRole = await this._groupRoleRepository.SelectAll()
            .Where(gr => gr.Id == id)
            .FirstOrDefaultAsync();
        if (groupRole is null)
            throw new ShamsheerException(404, "GroupRole is not found");

        return this._mapper.Map<GroupRoleForResultDto>(groupRole);
    }
}
