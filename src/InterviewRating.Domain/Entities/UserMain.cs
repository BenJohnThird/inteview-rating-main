using Microsoft.AspNetCore.Identity;

namespace InterviewRating.Domain.Entities;

public class UserMain : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
