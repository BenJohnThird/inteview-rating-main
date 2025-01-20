namespace InterviewRating.Application.Review.DTOs;

public class UpdateReviewRequestDTO
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string CompanyRepresentativeName { get; set; } = default!;
    public string? CompanyRepresentativeEmail { get; set; }
    public string Feedback { get; set; } = default!;
}
