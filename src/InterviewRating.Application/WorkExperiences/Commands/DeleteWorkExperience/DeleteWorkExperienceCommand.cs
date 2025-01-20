using MediatR;

namespace InterviewRating.Application.WorkExperiences.Commands.DeleteWorkExperience;

public class DeleteWorkExperienceCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
