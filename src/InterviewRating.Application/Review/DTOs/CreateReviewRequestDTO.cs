namespace InterviewRating.Application.Review.DTOs;

public class CreateReviewRequestDTO
{
    public string CompanyName { get; set; } = default!;
    public string CompanyRepresentativeName { get; set; } = default!;
    public string? CompanyRepresentativeEmail { get; set; }
    public string Feedback { get; set; } = default!;
}
