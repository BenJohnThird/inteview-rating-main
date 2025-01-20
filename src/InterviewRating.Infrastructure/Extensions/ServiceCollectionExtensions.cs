using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Interfaces;
using InterviewRating.Domain.Repositories;
using InterviewRating.Infrastructure.Authorization;
using InterviewRating.Infrastructure.Authorization.Requirements;
using InterviewRating.Infrastructure.Configuration;
using InterviewRating.Infrastructure.Persistence;
using InterviewRating.Infrastructure.Repositories;
using InterviewRating.Infrastructure.Seeders;
using InterviewRating.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewRating.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("InterviewRatingDB");
        services.AddDbContext<InterviewRatingDbContext>(options =>
        {
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(); // Mainly used for Serilog so that we can see the paramaters provided
        });

        services.AddIdentityApiEndpoints<UserMain>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<InterviewUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<InterviewRatingDbContext>();

        services.AddScoped<IInterviewRatingSeeder, InterviewRatingSeeder>();
        services.AddScoped<IWorkExperiencesRepository, WorkExperiencesRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality, builder =>
            {
                builder.RequireClaim(AppClaimTypes.Nationality, "Polish");
            })
            .AddPolicy(PolicyNames.Atleast20, builder =>
            {
                builder.AddRequirements(new MinimumAgeRequirement(20));
            });

        services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();

        services.Configure<BlobStorageSettings>(configuration.GetSection("BlobStorage"));
        services.AddScoped<IBlobStorageService, BlobStorageService>();

    }
}
