using FluentAssertions;
using InterviewRating.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Security.Principal;
using Xunit;

namespace InterviewRating.Application.User.Tests;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // Arrange
        var dateOfBirth = new DateOnly(1998, 11, 08);

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Email, "test@test.com"),
            new(ClaimTypes.Role, UserRoles.Admin),
            new(ClaimTypes.Role, UserRoles.User),
            new("Nationality", "Filipino"),
            new("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"))
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

        httpContextAccessorMock.Setup(x => x.HttpContext)
            .Returns(new DefaultHttpContext()
            {
                User = user
            });

        var userContext = new UserContext(httpContextAccessorMock.Object);
        // Act
        var currentUser = userContext.GetCurrentUser();

        // Assert
        currentUser.Should()
            .NotBeNull();

        currentUser.Id.Should()
            .Be("1");

        currentUser.Email.Should()
            .Be("test@test.com");

        currentUser.Roles.Should()
            .Contain(UserRoles.Admin, UserRoles.User);

        currentUser.DateOfBirth.Should()
            .Be(dateOfBirth);
    }

    [Fact()]
    public void GetCurrentUser_WIthNoUserContext_ThrowsInvalidOperationException()
    {
        // Arrange
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // Act
        Action action = () => userContext.GetCurrentUser();

        // Assert
        action.Should()
            .Throw<InvalidOperationException>();
    }
}