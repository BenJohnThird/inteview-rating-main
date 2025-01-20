using MediatR;

namespace InterviewRating.Application.User.Commands.RemoveUserRoleCommand;

public class RemoveUserRoleCommand : IRequest
{
    public string RoleName { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
}
