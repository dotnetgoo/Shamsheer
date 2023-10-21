using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.Exceptions;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Interfaces.Groups;

namespace Shamsheer.Service.Services.Groups;

public class GroupService : IGroupService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;
    private readonly IGroupRepository groupRepository;

    public GroupService(
        IMapper mapper,
        IUserRepository userRepository,
        IGroupRepository groupRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
        this.groupRepository = groupRepository;
    }
    public async Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto)
    {

        // After implementing PermissionServices
        var user = await this.userRepository.SelectAll()
            .Where(u => u.Id == dto.OwnerId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "Owner is not found");

        var mappedGroup = this.mapper.Map<Group>(dto);
        mappedGroup.ChatType = ChatType.Group;
        mappedGroup.InviteLink = "";
        mappedGroup.CreatedAt = DateTime.UtcNow;

        var result = await this.groupRepository.InsertAsync(mappedGroup);

        return this.mapper.Map<GroupForResultDto>(result);
    }

    public async Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto)
    {
        var group = await this.groupRepository.SelectAll()
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found");

        var mappedGroup = this.mapper.Map(dto, group);
        mappedGroup.UpdatedAt = DateTime.UtcNow;

        await this.groupRepository.UpdateAsync(mappedGroup);

        return this.mapper.Map<GroupForResultDto>(mappedGroup);
    }
    public async Task<bool> RemoveAsync(long id)
    {
        var group = await this.groupRepository.SelectAll()
            .Where (g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found");

        await this.groupRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync()
    {
        //   Do pagination logic
        var groups =  this.groupRepository.SelectAll().AsNoTracking();

         return this.mapper.Map<IEnumerable<GroupForResultDto>>(groups);
            
    }

    public async Task<GroupForResultDto> RetrieveByIdAsync(long id)
    {
        var group = await this.groupRepository.SelectAll()
            .Where (g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found");

        var mappedGroup = this.mapper.Map<GroupForResultDto>(group);

        return mappedGroup;
    }
}
