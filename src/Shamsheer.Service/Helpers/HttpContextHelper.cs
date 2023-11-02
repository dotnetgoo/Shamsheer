using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shamsheer.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;
    public static string UserRole => HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

    private static long _tempUserId;
}
