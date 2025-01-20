using AutoMapper;
using InterviewRating.Application.WorkExperiences.DTOs;
using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Queries.GetAllWorkExperiences;

public class GetAllWorkExperiencesQueryHandler(
    ILogger<GetAllWorkExperiencesQueryHandler> logger,
    IMapper mapper,
    IWorkExperiencesRepository workExperiencesRepository
    ) : IRequestHandler<GetAllWorkExperiencesQuery, IEnumerable<WorkExperiencesDTO>>
{
    public async Task<IEnumerable<WorkExperiencesDTO>> Handle(GetAllWorkExperiencesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all workexperiences");
        var experiences = await workExperiencesRepository.GetAllAsync();
        var experienceDTOs = mapper.Map<IEnumerable<WorkExperiencesDTO>>(experiences);
        return experienceDTOs!;
    }
}
