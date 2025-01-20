using AutoMapper;
using FluentAssertions;
using InterviewRating.Application.User;
using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience.Tests;

public class CreateWorkExperienceCommandHandlerTests
{
    [Fact()]
    public async void Hanlde_ForValidCommand_ReturnsCreatedWorkExperienceId()
    {
        // Arrange
        var logger = new Mock<ILogger<CreateWorkExperienceCommand>>();
        var mapperMock = new Mock<IMapper>();

        var command = new CreateWorkExperienceCommand();
        var workExperience = new WorkExperience();
        mapperMock.Setup(m => m.Map<WorkExperience>(command))
            .Returns(workExperience);

        var workExperienceRepositoryMock = new Mock<IWorkExperiencesRepository>();
        workExperienceRepositoryMock.Setup(repo => repo.Create(It.IsAny<WorkExperience>()))
            .ReturnsAsync(1);

        var userContextMock = new Mock<IUserContext>();
        var currentUser = new CurrentUser("owner-id", "test@test.com", [], null);
        userContextMock.Setup(u => u.GetCurrentUser())
            .Returns(currentUser);

        var commandHandler = new CreateWorkExperienceCommandHandler(
            logger.Object, mapperMock.Object, workExperienceRepositoryMock.Object
            );

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(1);
        workExperienceRepositoryMock.Verify(r => r.Create(workExperience), Times.Once());
    }
}