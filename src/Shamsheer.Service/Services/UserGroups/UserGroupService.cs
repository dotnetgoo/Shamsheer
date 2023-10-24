using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.UserGroup;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.UserGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.UserGroups;

public class UserGroupService : IUserGroupService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;
    private readonly IGroupRepository groupRepository;
    private readonly IUserGroupRepository userGroupRepository;

    public UserGroupService(
        IMapper mapper, 
        IUserRepository userRepository, 
        IGroupRepository groupRepository,
        IUserGroupRepository userGroupRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
        this.groupRepository = groupRepository;
        this.userGroupRepository = userGroupRepository;
    }

    public async Task<UserGroupForResultDto> CreateAsync(UserGroupForCreationDto dto)
    {
        var user = await this.userRepository.SelectAll()
            .Where(u => u.Id == dto.MemberId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var group = await this.groupRepository.SelectAll()
            .Where(g => g.Id == dto.GroupId)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var mappedUserGroup = this.mapper.Map<UserGroup>(dto);
        mappedUserGroup.CreatedAt = DateTime.UtcNow;

        var result = await this.userGroupRepository.InsertAsync(mappedUserGroup);

        return this.mapper.Map<UserGroupForResultDto>(result);
    }

    public async Task<UserGroupForResultDto> ModifyAsync(long id, UserGroupForUpdateDto dto)
    {
        var userGroup = await this.userGroupRepository.SelectAll()
            .Where(ug => ug.Id == id)
            .FirstOrDefaultAsync();
        if (userGroup is null)
            throw new ShamsheerException(404, "User group is not found.");

        var user = await this.userRepository.SelectAll()
            .Where(u => u.Id == dto.MemberId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var group = await this.groupRepository.SelectAll()
            .Where(g => g.Id == dto.GroupId)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var mappedUserGroup = this.mapper.Map(dto, userGroup);
        mappedUserGroup.UpdatedAt = DateTime.UtcNow;

        await this.userGroupRepository.UpdateAsync(mappedUserGroup);

        return this.mapper.Map<UserGroupForResultDto>(mappedUserGroup);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var userGroup = await this.userGroupRepository.SelectAll()
            .Where(ug => ug.Id == id)
            .FirstOrDefaultAsync();
        if (userGroup is null)
            throw new ShamsheerException(404, "User group is not found.");

        return await this.userGroupRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserGroupForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var userGroup = await this.userGroupRepository.SelectAll()
            .Include(ug => ug.Member)
            .ThenInclude(u =>u.Assets)
            .Include(ug => ug.Group)
            .ThenInclude(g => g.Owner)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<UserGroupForResultDto>>(userGroup);
    }

    public async Task<UserGroupForResultDto> RetrieveByIdAsync(long id)
    {
        var userGroup = await this.userGroupRepository.SelectAll()
            .Where(ug => ug.Id == id)
            .Include(ug => ug.Member)
            .ThenInclude(u => u.Assets)
            .Include(ug => ug.Group)
            .ThenInclude(g => g.Owner)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (userGroup is null)
            throw new ShamsheerException(404, "User group is not found.");

        return this.mapper.Map<UserGroupForResultDto>(userGroup);
    }
}
