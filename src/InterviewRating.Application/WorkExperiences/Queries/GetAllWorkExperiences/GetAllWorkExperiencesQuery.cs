using InterviewRating.Application.WorkExperiences.DTOs;
using MediatR;

namespace InterviewRating.Application.WorkExperiences.Queries.GetAllWorkExperiences;

public class GetAllWorkExperiencesQuery : IRequest<IEnumerable<WorkExperiencesDTO>>
{
}
