using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.DTOs.Groups;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Interfaces.Groups;

namespace Shamsheer.Service.Services.Groups;

public class GroupService : IGroupService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;

    public GroupService(
        IMapper mapper,
        IUserRepository userRepository,
        IGroupRepository groupRepository)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
        this._groupRepository = groupRepository;
    }
    public async Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto)
    {

        // After implementing PermissionServices
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.OwnerId)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ShamsheerException(404, "Owner is not found.");

        var mappedGroup = _mapper.Map<Group>(dto);
        mappedGroup.ChatType = ChatType.Group;
        mappedGroup.InviteLink = "";
        mappedGroup.CreatedAt = DateTime.UtcNow;

        var result = await _groupRepository.InsertAsync(mappedGroup);

        return _mapper.Map<GroupForResultDto>(result);
    }

    public async Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        var mappedGroup = _mapper.Map(dto, group);
        mappedGroup.UpdatedAt = DateTime.UtcNow;

        await _groupRepository.UpdateAsync(mappedGroup);

        return this._mapper.Map<GroupForResultDto>(mappedGroup);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var group = await _groupRepository.SelectAll()
            .Where (g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found.");

        await _groupRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync()
    {
        //   Do pagination logic
        var groups =  _groupRepository.SelectAll().AsNoTracking();

         return _mapper.Map<IEnumerable<GroupForResultDto>>(groups);    
    }

    public async Task<GroupForResultDto> RetrieveByIdAsync(long id)
    {
        var group = await _groupRepository.SelectAll()
            .Where (g => g.Id == id)
            .FirstOrDefaultAsync();
        if (group is null)
            throw new ShamsheerException(404, "Group is not found");

        var mappedGroup = _mapper.Map<GroupForResultDto>(group);

        return mappedGroup;
    }
}
