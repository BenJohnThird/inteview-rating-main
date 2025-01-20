using InterviewRating.Domain.Entities;

namespace InterviewRating.Domain.Repositories;

public interface IWorkExperiencesRepository
{
    Task<IEnumerable<WorkExperience>> GetAllAsync();
    Task<WorkExperience?> GetByIdAsync(int id);
    Task<int> Create(WorkExperience workExperience);
    Task DeleteWorkExperience(WorkExperience workExperience);
    Task SaveChanges();
}
