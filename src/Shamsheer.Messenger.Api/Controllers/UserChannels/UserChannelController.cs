using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Shamsheer.Messenger.Api.Helpers;
using Shamsheer.Service.Configurations;
=======
>>>>>>> f547e2782442944ef96045807bcde6a4041df003
using Shamsheer.Service.DTOs.UserChannels;
using Shamsheer.Service.Interfaces.UserChannel;

namespace Shamsheer.Messenger.Api.Controllers.UserChannels;

public class UserChannelController : BaseController
{
    private readonly IUserChannelService _userChannelService;

    public UserChannelController(IUserChannelService userChannelService)
    {
        _userChannelService = userChannelService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserChannelForCreationDto dto)
    => Ok(await _userChannelService.CreateAsync(dto));

    [HttpGet()]
<<<<<<< HEAD
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response()
        {
            Code = 200,
            Message = "Success",
            Data = await this._userChannelService.RetrieveAllAsync(@params)
        });
=======
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _userChannelService.RetrieveAllAsync());
>>>>>>> f547e2782442944ef96045807bcde6a4041df003

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userChannelService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserChannelForUpdateDto dto)
        => Ok(await _userChannelService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userChannelService.RemoveAsync(id));
}