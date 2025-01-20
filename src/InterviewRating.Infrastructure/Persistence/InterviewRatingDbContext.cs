using InterviewRating.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterviewRating.Infrastructure.Persistence
{
    internal class InterviewRatingDbContext(DbContextOptions options) : IdentityDbContext<UserMain>(options)
    {
        internal DbSet<Address> Addresses { get; set; }
        internal DbSet<WorkExperience> WorkExperiences { get; set; }
        internal DbSet<LoginHistory> LoginHistories { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<UserAuth> UserAuths { get; set; }
        internal DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkExperience>()
                .OwnsOne(work => work.Address);
        }
    }
}
