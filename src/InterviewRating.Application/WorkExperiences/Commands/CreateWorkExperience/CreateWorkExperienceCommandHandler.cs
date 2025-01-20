using AutoMapper;
using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience;

public class CreateWorkExperienceCommandHandler(
    ILogger<CreateWorkExperienceCommand> logger,
    IMapper mapper,
    IWorkExperiencesRepository workExperiencesRepository
    ) : IRequestHandler<CreateWorkExperienceCommand, int>
{
    public async Task<int> Handle(CreateWorkExperienceCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new work experience");
        var workExperience = mapper.Map<WorkExperience>(request);

        int id = await workExperiencesRepository.Create(workExperience);
        return id;
    }
}
