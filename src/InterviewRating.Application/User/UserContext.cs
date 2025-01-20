using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InterviewRating.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user is null)
        {
            throw new InvalidOperationException("User context is not prsent");
        }

        if (user.Identity is null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = GetClaimValue(ClaimTypes.NameIdentifier, user);
        var email = GetClaimValue(ClaimTypes.Email, user);
        var roles = GetClaimValues(ClaimTypes.Role, user);
        var dateOfBirthStr = user.FindFirst(c => c.Type == "DateOfBirth")?.Value;
        var nationality = user.FindFirst(c => c.Type == "Nationality")?.Value;
        var dateOfBirth = dateOfBirthStr == null ? (DateOnly?)null : DateOnly.ParseExact(dateOfBirthStr, "yyyy-MM-dd");

        return new CurrentUser(userId!, email!, roles, dateOfBirth);
    }

    private string? GetClaimValue(string claimTypes, ClaimsPrincipal user)
    {
        var appClaim = user.FindFirst(claim => claim.Type == claimTypes);
        if (appClaim == null)
        {
            return null;
        }

        return appClaim.Value;
    }

    private IEnumerable<string> GetClaimValues(string claimTypes, ClaimsPrincipal user)
    {
        return user.Claims
            .Where(claim => claim.Type == claimTypes)
            .Select(claim => claim.Value);
    }
}
