using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shamsheer.Service.Exceptions;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Service.DTOs.UserChannels;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.Interfaces.UserChannel;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.Extensions;

namespace Shamsheer.Service.Services.UserChannels;
public class UserChannelService : IUserChannelService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUserChannelRepository _userChannelRepository;

    public UserChannelService(
        IMapper mapper,
        IUserRepository userRepository,
        IChannelRepository channelRepository,
        IUserChannelRepository userChannelRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _channelRepository = channelRepository;
        _userChannelRepository = userChannelRepository;
    }

    public async Task<UserChannelForResultDto> CreateAsync(UserChannelForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.SubscriberId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var channel = await _channelRepository.SelectAll()
            .Where(ch => ch.Id == dto.ChannelId)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found.");

        var mappedUserChannel = _mapper.Map<UserChannel>(dto);

        mappedUserChannel.CreatedAt = DateTime.UtcNow;

        var result = await _userChannelRepository.InsertAsync(mappedUserChannel);

        return _mapper.Map<UserChannelForResultDto>(result);
    }

    public async Task<UserChannelForResultDto> ModifyAsync(long id, UserChannelForUpdateDto dto)
    {
        var userChannel = await _userChannelRepository.SelectAll()
            .Where(uch => uch.Id == id)
            .FirstOrDefaultAsync();

        if (userChannel is null)
            throw new ShamsheerException(404, "User channel is not found.");

        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.SubscriberId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ShamsheerException(404, "User is not found.");

        var channel = await _channelRepository.SelectAll()
            .Where(g => g.Id == dto.ChannelId)
            .FirstOrDefaultAsync();

        if (channel is null)
            throw new ShamsheerException(404, "Channel is not found.");

        var mappedUserChannel = _mapper.Map(dto, userChannel);
        mappedUserChannel.UpdatedAt = DateTime.UtcNow;

        await _userChannelRepository.UpdateAsync(mappedUserChannel);

        return _mapper.Map<UserChannelForResultDto>(mappedUserChannel);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var userChannel = await _userChannelRepository.SelectAll()
            .Where(uch => uch.Id == id)
            .FirstOrDefaultAsync();

        if (userChannel is null)
            throw new ShamsheerException(404, "User channel is not found.");

        return await _userChannelRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserChannelForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var userChannels = await _userChannelRepository.SelectAll()
            .Include(uch => uch.Subscriber)
            .ThenInclude(u => u.Assets)
            .Include(uch => uch.Channel)
            .ThenInclude(ch => ch.Owner)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserChannelForResultDto>>(userChannels);
    }

    public async Task<UserChannelForResultDto> RetrieveByIdAsync(long id)
    {
        var userChannel = await _userChannelRepository.SelectAll()
            .Where(uch => uch.Id == id)
            .Include(uch => uch.Subscriber)
            .ThenInclude(u => u.Assets)
            .Include(uch => uch.Channel)
            .ThenInclude(ch => ch.Owner)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (userChannel is null)
            throw new ShamsheerException(404, "User channel is not found.");

        return _mapper.Map<UserChannelForResultDto>(userChannel);
    }
}
