using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.Configurations;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Extensions;
using Shamsheer.Service.Interfaces.Authorizations.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Service.Services.Authorizations.Channels;

public class ChannelPermissionService : IChannelPermissionService
{
<<<<<<< HEAD
    private readonly IMapper mapper;
=======
    private readonly IMapper _mapper;
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
    private readonly IChannelPermissionRepository _channelPermissionRepository;

    public ChannelPermissionService(IChannelPermissionRepository channelPermissionRepository, IMapper mapper)
    {
<<<<<<< HEAD
        this.mapper = mapper;
        this._channelPermissionRepository = channelPermissionRepository;
=======
        _mapper = mapper;
        _channelPermissionRepository = channelPermissionRepository;
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
    }


    public async Task<ChannelPermissionForResultDto> CreateAsync(ChannelPermissionType type)
    {
<<<<<<< HEAD
        var channelPermission = await this._channelPermissionRepository.SelectAll()
=======
        var channelPermission = await _channelPermissionRepository.SelectAll()
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
            .Where(cp => cp.Type == type)
            .FirstOrDefaultAsync();
        if(channelPermission is not null)
            throw new ShamsheerException(409, "ChannelPermission already exist");

        var mappedChannelPermission = new ChannelPermission()
        {
            Type = type,
            CreatedAt = DateTime.UtcNow,
        };

<<<<<<< HEAD
        var result = await this._channelPermissionRepository.InsertAsync(mappedChannelPermission);   
=======
        var result = await _channelPermissionRepository.InsertAsync(mappedChannelPermission);   
>>>>>>> f547e2782442944ef96045807bcde6a4041df003

        return _mapper.Map<ChannelPermissionForResultDto>(result);
    }

    public async Task<ChannelPermissionForResultDto> ModifyAsync(long id, ChannelPermissionType type)
    {
<<<<<<< HEAD
        var channelPermission = await this._channelPermissionRepository.SelectAll()
=======
        var channelPermission = await _channelPermissionRepository.SelectAll()
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
            .Where(cp => cp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

        var mappedChannelPermission = new ChannelPermission()
        {
            Id = id,
            Type = type,
            UpdatedAt = DateTime.UtcNow,
        };
<<<<<<< HEAD
        var mapped = await this._channelPermissionRepository.UpdateAsync(mappedChannelPermission);
=======
        var mapped = await _channelPermissionRepository.UpdateAsync(mappedChannelPermission);
>>>>>>> f547e2782442944ef96045807bcde6a4041df003

        return _mapper.Map<ChannelPermissionForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
<<<<<<< HEAD
        var channelPermission = await this._channelPermissionRepository.SelectAll()
=======
        var channelPermission = await _channelPermissionRepository.SelectAll()
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
            .Where(cp => cp.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "ChannelPermission is not found");

<<<<<<< HEAD
        await this._channelPermissionRepository.DeleteAsync(id);
=======
        await _channelPermissionRepository.DeleteAsync(id);
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
        return true;
    }

    public async Task<IEnumerable<ChannelPermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
<<<<<<< HEAD
        var channelPermissions = await this._channelPermissionRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<ChannelPermissionForResultDto>>(channelPermissions);
=======
        var channelPermission = _channelPermissionRepository.SelectAll()
            .AsNoTracking();

        return _mapper.Map<IEnumerable<ChannelPermissionForResultDto>>(channelPermission);
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
    }

    public async Task<ChannelPermissionForResultDto> RetrieveByIdAsync(long id)
    {
<<<<<<< HEAD
        var channelPermission = await this._channelPermissionRepository.SelectAll()
=======
        var channelPermission = await _channelPermissionRepository.SelectAll()
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
            .Where(cp => cp.Id == id)
            .FirstOrDefaultAsync();

        if (channelPermission is null)
            throw new ShamsheerException(404, "GroupPermission is not found");

        return _mapper.Map<ChannelPermissionForResultDto>(channelPermission);
    }
}
