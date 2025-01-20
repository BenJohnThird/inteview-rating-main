using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.User.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler(
        ILogger<UpdateUserDetailsCommandHandler> logger,
        IUserContext userContext,
        IUserStore<UserMain> userStore
        ) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            logger.LogInformation("Updating user details: {UserId}, with {@Request}", user!.Id, request);

            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
            if (dbUser is null)
            {
                throw new NotFoundException(nameof(UserMain), user!.Id);
            }

            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;

            await userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
