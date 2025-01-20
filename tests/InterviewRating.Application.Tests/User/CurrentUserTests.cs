using FluentAssertions;
using InterviewRating.Domain.Constants;
using Xunit;

namespace InterviewRating.Application.User.Tests;

public class CurrentUserTests
{
    [Theory()]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@email.com", [UserRoles.Admin, UserRoles.User], null);

        // act
        var isInRole = currentUser.IsInRole(roleName);

        // assert
        isInRole.Should()
            .BeTrue();
    }

    [Fact()]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@email.com", [], null);

        // act
        var isInRole = currentUser.IsInRole(UserRoles.Admin);

        // assert
        isInRole.Should()
            .BeFalse();
    }
}