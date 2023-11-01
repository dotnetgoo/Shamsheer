using Microsoft.Extensions.Configuration;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Exceptions;
using Shamsheer.Service.Interfaces.Users;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Shamsheer.Service.Services.Users;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthService(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }
    public async Task<LoginResultDto> AuthenticateAsync(LoginDto login)
    {
        var user = await _userService.RetrieveByEmailAsync(login.Email);
        if (user is null) // Do logic for cheking password
            throw new ShamsheerException(400, "Email or Password in incorrect");

        return new LoginResultDto
        {
            Token = GenerateToken(user)
        };
    }
    private string GenerateToken(UserForResultDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.FirstName),
                 new Claim(ClaimTypes.Email, user.Email)
                 // To Do  : Role logic 

            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
