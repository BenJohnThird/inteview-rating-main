using FluentAssertions;
using InterviewRating.Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace InterviewRating.Infrastructure.Authorization.Requirements.Tests;

public class MinimumAgeRequirementHandlerTests
{
    [Fact()]
    public async void HandleRequirementAsync_MinimumAgeRequirement_ShouldSucceed()
    {
        // Arrange
        var logger = new Mock<ILogger<MinimumAgeRequirementHandler>>();
        var currentUser = new CurrentUser("id", "ben@email.com", [], new DateOnly(1998, 11, 08));
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(m => m.GetCurrentUser())
            .Returns(currentUser);

        var requirement = new MinimumAgeRequirement(20);
        var handler = new MinimumAgeRequirementHandler(logger.Object, userContextMock.Object);
        var context = new AuthorizationHandlerContext([requirement], null, null);
        // Act
        await handler.HandleAsync(context);
        // Assert
        context.HasSucceeded.Should().BeTrue();

    }

    [Fact()]
    public async void HandleRequirementAsync_MinimumAgeRequirement_ShouldFail()
    {
        // Arrange
        var logger = new Mock<ILogger<MinimumAgeRequirementHandler>>();
        var currentUser = new CurrentUser("id", "ben@email.com", [], new DateOnly(2024, 11, 08));
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(m => m.GetCurrentUser())
            .Returns(currentUser);

        var requirement = new MinimumAgeRequirement(20);
        var handler = new MinimumAgeRequirementHandler(logger.Object, userContextMock.Object);
        var context = new AuthorizationHandlerContext([requirement], null, null);
        // Act
        await handler.HandleAsync(context);
        // Assert
        context.HasFailed.Should().BeTrue();

    }
}