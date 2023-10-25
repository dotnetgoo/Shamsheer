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
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Extensions;

namespace Shamsheer.Service.Services.Channels;
public class ChannelService : IChannelService
{
    private readonly IMapper _mapper;
    private readonly IChannelRepository _channelRepository;
    private readonly IUserRepository _userRepository;

    public ChannelService(IMapper mapper,
                          IChannelRepository channelRepository,
                          IUserRepository userRepository)
    {
        _mapper = mapper;
        _channelRepository = channelRepository;
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

        var result = await _channelRepository.InsertAsync(mapped);
        return _mapper.Map<ChannelForResultDto>(result);
    }

    public async Task<ChannelForResultDto> ModifyAsync(long id, ChannelForUpdateDto dto)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        var mapped = _mapper.Map(dto, channel);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _channelRepository.UpdateAsync(mapped);

        return _mapper.Map<ChannelForResultDto>(mapped);
    }
    public async Task<bool> RemoveAsync(long id)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        await _channelRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ChannelForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var channels = await _channelRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ChannelForResultDto>>(channels);
    }

    public async Task<ChannelForResultDto> RetrieveByIdAsync(long id)
    {
        var channel = await _channelRepository.SelectAll()
            .Where(ch => ch.Id == id)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found!");

        return _mapper.Map<ChannelForResultDto>(channel);
    }
}

