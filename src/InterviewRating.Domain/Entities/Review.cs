namespace InterviewRating.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public Guid SpecialId { get; private set; } = Guid.NewGuid();
    public string CompanyName { get; set; } = default!;
    public string CompanyRepresentativeName { get; set; } = default!;
    public string? CompanyRepresentativeEmail { get; set; }
    public string Feedback { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
