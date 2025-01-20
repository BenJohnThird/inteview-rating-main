using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Repositories;
using InterviewRating.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InterviewRating.Infrastructure.Repositories;

internal class WorkExperiencesRepository(InterviewRatingDbContext dbContext) : IWorkExperiencesRepository
{
    public async Task<int> Create(WorkExperience workExperience)
    {
        dbContext.WorkExperiences.Add(workExperience);
        await dbContext.SaveChangesAsync();
        return workExperience.Id;
    }

    public async Task DeleteWorkExperience(WorkExperience workExperience)
    {
        dbContext.Remove(workExperience);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkExperience>> GetAllAsync()
    {
        var workExperiences = await dbContext.WorkExperiences.ToListAsync();
        return workExperiences;
    }

    public async Task<WorkExperience?> GetByIdAsync(int id)
    {
        var workExperience = await dbContext.WorkExperiences.FindAsync(id);
        return workExperience;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
