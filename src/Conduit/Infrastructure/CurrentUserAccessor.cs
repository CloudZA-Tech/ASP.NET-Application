using System.Security.Claims;

namespace Conduit.Infrastructure;

public class CurrentUserAccessor(IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    public string? GetCurrentUsername() =>
        httpContextAccessor
            .HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
            ?.Value;
}
