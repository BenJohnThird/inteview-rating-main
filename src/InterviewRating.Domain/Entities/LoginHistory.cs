namespace InterviewRating.Domain.Entities;

public class LoginHistory
{
    public int Id { get; set; }
    public DateTime LoginDateTime { get; set; }
    public int UserAuthId { get; set; }
    public UserAuth UserAuth { get; set; } = new();
}
