using MediatR;

namespace InterviewRating.Application.User.Commands.AssignUserRoleCommand;

public class AssignUserRoleCommand : IRequest
{
    public string RoleName { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
}
