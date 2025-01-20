using AutoMapper;
using InterviewRating.Application.WorkExperiences.DTOs;
using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Queries.GetWorkExperienceById;

public class GetWorkExperienceByIdHandler(
    ILogger<GetWorkExperienceByIdHandler> logger,
    IWorkExperiencesRepository workExperiencesRepository,
    IMapper mapper
    ) : IRequestHandler<GetWorkExperienceByIdQuery, WorkExperiencesDTO?>
{
    public async Task<WorkExperiencesDTO?> Handle(GetWorkExperienceByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting WorkExperience by {request.Id}");
        var experience = await workExperiencesRepository.GetByIdAsync(request.Id);
        var experienceDTO = mapper.Map<WorkExperiencesDTO>(experience);
        return experienceDTO;
    }
}