using System;

namespace Shamsheer.Service.DTOs.Auth;

public class VerificationDto
{
    public int Code { get; set; }
    public int Attempt { get; set; }
    public DateTime CreatedAt { get; set; }
}
