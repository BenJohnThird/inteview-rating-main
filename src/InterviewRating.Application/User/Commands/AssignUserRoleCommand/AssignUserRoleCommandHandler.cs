using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.User.Commands.AssignUserRoleCommand;

public class AssignUserRoleCommandHandler(
    ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<UserMain> userManager,
    RoleManager<IdentityRole> roleManager
    ) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role: {@Request}", request);
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

        await userManager.AddToRoleAsync(user, role.Name!);
    }
}
