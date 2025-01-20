using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.User.Commands.RemoveUserRoleCommand;

public class RemoveUserRoleCommandHandler(
    ILogger<RemoveUserRoleCommandHandler> logger,
    UserManager<UserMain> userManager,
    RoleManager<IdentityRole> roleManager
    ) : IRequestHandler<RemoveUserRoleCommand>
{
    public async Task Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Removing user role: {@Request}", request);
        var user = await userManager.FindByEmailAsync(request.UserEmail);
        if (user is null)
        {
            throw new NotFoundException(nameof(UserMain), request.UserEmail);
        }

        var role = await roleManager.FindByNameAsync(request.RoleName);
        if (role is null)
        {
            throw new NotFoundException(nameof(IdentityRole), request.RoleName);
        }

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
