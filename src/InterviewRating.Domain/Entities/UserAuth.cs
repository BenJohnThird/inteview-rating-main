using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewRating.Domain.Entities
{
    public class UserAuth
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = new();
        public List<LoginHistory> LoginHistories { get; set; } = new();
    }
}
