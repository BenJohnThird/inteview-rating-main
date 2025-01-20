namespace InterviewRating.Domain.Entities
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string CompanyName { get; set; } = default!;
        public string[] Responsibilities { get; set; } = default!;
        public bool? IsCurrentCompany { get; set; }
        public Address? Address { get; set; }
        public string[] TechStack { get; set; } = [];
        public DateOnly StartDate { get; set; } = default!;
        public DateOnly? EndDate { get; set; }
    }
}
