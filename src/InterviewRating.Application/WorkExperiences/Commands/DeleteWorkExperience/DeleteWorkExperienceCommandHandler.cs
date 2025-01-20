using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Commands.DeleteWorkExperience;

public class DeleteWorkExperienceCommandHandler(
    ILogger<DeleteWorkExperienceCommandHandler> logger,
    IWorkExperiencesRepository workExperiencesRepository
    ) : IRequestHandler<DeleteWorkExperienceCommand, bool>
{
    public async Task<bool> Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete work experience with id of {request.Id}");
        var workExperience = await workExperiencesRepository.GetByIdAsync(request.Id);
        if (workExperience is null)
        {
            return false;
        }

        await workExperiencesRepository.DeleteWorkExperience(workExperience);
        return true;
    }
}
