using FluentValidation.TestHelper;
using Xunit;

namespace InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience.Tests;

public class CreateWorkExperienceCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var command = new CreateWorkExperienceCommand()
        {
            CompanyName = "AMCS",
            Description = "AMCS New Developer",
            Name = "Senior Software Engineer",
            IsCurrentCompany = true,
            TechStack = ["Angular", "C#", "SQL", "Typescript"],
            Street = "Balagtas Street",
            PostalCode = "1740",
            City = "Las Pinas",
            Country = "Philippines",
            Responsibilities = ["1", "2", "3", "4"]
        };

        var validator = new CreateWorkExperienceCommandValidator();

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        // Arrange
        var command = new CreateWorkExperienceCommand()
        {
            CompanyName = "A",
            Description = "",
            Name = "S",
            IsCurrentCompany = true,
            TechStack = [],
            Street = "Balagtas Street",
            PostalCode = "1740",
            City = "Las Pinas",
            Country = "Malaysia",
            Responsibilities = ["1", "2", "3", "4", "5"]
        };

        var validator = new CreateWorkExperienceCommandValidator();

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Name);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.TechStack);
        result.ShouldHaveValidationErrorFor(c => c.Responsibilities);
        result.ShouldHaveValidationErrorFor(c => c.Country);
    }

    [Theory()]
    [InlineData("Philippines")]
    [InlineData("USA")]
    [InlineData("Australia")]
    [InlineData("Singapore")]
    public void Validator_ForValidCountry_ShouldNotHaveValidationErrors(string country)
    {
        // Arrange
        var validator = new CreateWorkExperienceCommandValidator();
        var command = new CreateWorkExperienceCommand() { Country = country };

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(c => c.Country);
    } 
}