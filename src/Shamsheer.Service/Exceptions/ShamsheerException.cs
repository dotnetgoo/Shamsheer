using System;

namespace Shamsheer.Service.Exceptions;

public class ShamsheerException : Exception
{
    public int StatusCode { get; set; }

    public ShamsheerException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
