using InterviewRating.Application.WorkExperiences.DTOs;
using MediatR;

namespace InterviewRating.Application.WorkExperiences.Queries.GetWorkExperienceById;

public class GetWorkExperienceByIdQuery(int id) : IRequest<WorkExperiencesDTO?>
{
    public int Id { get; } = id;
}
