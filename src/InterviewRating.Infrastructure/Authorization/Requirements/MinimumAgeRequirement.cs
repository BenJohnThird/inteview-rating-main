using Microsoft.AspNetCore.Authorization;

namespace InterviewRating.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
{
    public int MinimumAge { get; set; } = minimumAge;
}
