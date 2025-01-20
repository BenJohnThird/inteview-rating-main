using InterviewRating.Domain.Constants;
using InterviewRating.Domain.Entities;
using InterviewRating.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InterviewRating.Infrastructure.Seeders
{
    internal class InterviewRatingSeeder(InterviewRatingDbContext dbContext) : IInterviewRatingSeeder
    {
        public async Task Seed()
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            if (!await dbContext.Database.CanConnectAsync())
            {
                return;
            }

            if (!dbContext.WorkExperiences.Any())
            {
                var experiences = GetWorkExperiences();
                dbContext.WorkExperiences.AddRange(experiences);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = [
                new (UserRoles.Admin) {
                    NormalizedName = UserRoles.Admin.ToUpper(),
                },
                new (UserRoles.User) {
                    NormalizedName = UserRoles.User.ToUpper(),
                },
            ];

            return roles;
        }

        private IEnumerable<WorkExperience> GetWorkExperiences()
        {
            List<WorkExperience> workExperiences = [
                new() {
                    CompanyName = "Accenture",
                    Name = "Associate Software Engineer",
                    Description = "Tech Stack: Angular | C#.NET | Typescript",
                    IsCurrentCompany = false,
                    Responsibilities = [
                        "Integrate Web APIs",
                    ],
                    Address = new () {
                        City = "Mandaluyong",
                        Street = "Robinsons",
                        PostalCode = "1 740",
                        Country = "Philippines",
                    }
                },
                new() {
                    CompanyName = "Accenture",
                    Name = "Senior Software Engineer",
                    Description = "Tech Stack: Angular | NodeJS | Typescript",
                    IsCurrentCompany = false,
                    Responsibilities = [
                        "Integrate Web APIs",
                    ],
                    Address = new Address() {
                        City = "Muntinlupa",
                        Street = "Alabang",
                        PostalCode = "1740",
                        Country = "Philippines",
                    }
                },
                new() {
                    CompanyName = "Legalsight",
                    Name = "Angular Frontend Developer",
                    Description = "Tech Stack: Angular | Java Spring | Typescript",
                    IsCurrentCompany = true,
                    Responsibilities = [
                        "Integrate Web APIs",
                    ],
                    Address = new Address() {
                        City = "Las Pinas",
                        Street = "Clover",
                        PostalCode = "1740",
                        Country = "Philippines",
                    }
                },
                new() {
                    CompanyName = "Etica",
                    Name = "Senior Frontend Developer",
                    Description = "Tech Stack: Angular | C# .NET | Typescript",
                    IsCurrentCompany = false,
                    Responsibilities = [
                        "Integrate Web APIs",
                    ],
                    Address = new Address() {
                        City = "Las Pinas",
                        Street = "Clover",
                        PostalCode = "1740",
                        Country = "Philippines",
                    }
                },
                new() {
                    CompanyName = "AMCS",
                    Name = "Senior Software Engineer",
                    Description = "Tech Stack: Angular | C# .NET | Typescript",
                    IsCurrentCompany = false,
                    Responsibilities = [
                        "Integrate Web APIs",
                    ],
                    Address = new Address() {
                        City = "Las Pinas",
                        Street = "Balagtas",
                        PostalCode = "1740",
                        Country = "Philippines",
                    }
                },
            ];

            return workExperiences;
        }
    }
}
