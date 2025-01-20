using AutoMapper;
using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Commands.UpdateWorkExperience;

public class UpdateWorkExperienceCommandHandler(
    ILogger<UpdateWorkExperienceCommandHandler> logger,
    IWorkExperiencesRepository workExperiencesRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateWorkExperienceCommand, WorkExperience?>
{
    public async Task<WorkExperience?> Handle(UpdateWorkExperienceCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating work experience with id of {request.Id}");
        var workExperience = await workExperiencesRepository.GetByIdAsync(request.Id);
        if (workExperience is null)
        {
            return null;
        }

        mapper.Map(request, workExperience);
        await workExperiencesRepository.SaveChanges();
        return workExperience;
    }
}
