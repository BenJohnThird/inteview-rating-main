using MediatR;

namespace InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience;

public class CreateWorkExperienceCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string CompanyName { get; set; } = default!;
    public string[] Responsibilities { get; set; } = [];
    public bool? IsCurrentCompany { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string[] TechStack { get; set; } = [];
}
