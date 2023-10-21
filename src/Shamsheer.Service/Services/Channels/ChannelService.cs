using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.Channels;
using Shamsheer.Service.Interfaces.Channels;

namespace Shamsheer.Service.Services.Channels;
public class ChannelService : IChannelService
{
    private readonly IMapper _mapper;
    private readonly IChannelRepository _repository;
    private readonly IUserRepository _userRepository;

    public ChannelService(IMapper mapper,
                          IChannelRepository repository,
                          IUserRepository userRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<ChannelForResultDto> AddAsync(ChannelForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
             .Where(u => u.Id == dto.OwnerId)
             .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found!");


        var mapped = _mapper.Map<Channel>(dto);
        mapped.ChatType = ChatType.Channel;
        mapped.InviteLink = "";
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mapped);
        return _mapper.Map<ChannelForResultDto>(result);
    }

    public async Task<ChannelForResultDto> ModifyAsync(long id, ChannelForUpdateDto dto)
    {
        var channel = await _repository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        var mapped = _mapper.Map(dto, channel);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<ChannelForResultDto>(mapped);
    }

    public Task<ChannelForResultDto> ModifyDescriptionAsync(string description)
    {
        throw new NotImplementedException();
    }

    public Task<ChannelForResultDto> ModifyTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<ChannelForResultDto> ModifyUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var channel = await _repository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ChannelForResultDto>> RetrieveAllAsync()
    {
        var channels = _repository.SelectAll().AsNoTracking();

        return _mapper.Map<IEnumerable<ChannelForResultDto>>(channels);
    }

    public async Task<ChannelForResultDto> RetrieveByIdAsync(long id)
    {
        var channel = await _repository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        return _mapper.Map<ChannelForResultDto>(channel);
    }
}

