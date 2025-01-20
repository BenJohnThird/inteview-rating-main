using InterviewRating.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace InterviewRating.Infrastructure.Authorization;

public class InterviewUserClaimsPrincipalFactory(
    UserManager<UserMain> userManager, 
    RoleManager<IdentityRole> roleManager, 
    IOptions<IdentityOptions> options
    ) : UserClaimsPrincipalFactory<UserMain, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(UserMain user)
    {
        var id = await GenerateClaimsAsync(user);

        if (user.Nationality != null)
        {
            id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
        }

        if (user.DateOfBirth != null)
        {
            id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }

        return new ClaimsPrincipal(id);
    }
}
