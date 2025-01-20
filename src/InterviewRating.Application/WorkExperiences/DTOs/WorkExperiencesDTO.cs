namespace InterviewRating.Application.WorkExperiences.DTOs;

public class WorkExperiencesDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string CompanyName { get; set; } = default!;
    public string[] Responsibilities { get; set; } = default!;
    public bool? IsCurrentCompany { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public DateOnly StartDate { get; set; } = default!;
    public DateOnly? EndDate { get; set; }
    public string[] TechStack { get; set; } = [];
}
