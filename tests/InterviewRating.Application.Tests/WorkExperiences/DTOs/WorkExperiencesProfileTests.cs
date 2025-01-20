using AutoMapper;
using FluentAssertions;
using InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience;
using InterviewRating.Domain.Entities;
using Xunit;

namespace InterviewRating.Application.WorkExperiences.DTOs.Tests;

public class WorkExperiencesProfileTests
{
    private IMapper _mapper;

    public WorkExperiencesProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<WorkExperiencesProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForWorkExperienceDTO_MapsCorrectly()
    {
        // Arrange
        var workExperience = new WorkExperience()
        {
            Id = 1,
            Name = "Senior Software Engineer",
            CompanyName = "AMCS",
            Description = "Ben is favored",
            TechStack = ["Angular", "C#", "SQL"],
            IsCurrentCompany = true,
            Address = new Address()
            {
                Street = "Balagtas Street",
                City = "Las Pinas",
                Country = "Philippines",
                PostalCode = "1740",
            },
            Responsibilities = ["1", "2", "3", "4"],
            StartDate = new DateOnly(1998, 11, 01)
        };

        // Act
        var workExperienceDTO = _mapper.Map<WorkExperience>(workExperience);

        // Assert
        workExperienceDTO.Should().NotBeNull();
        workExperienceDTO.Id.Should().Be(workExperience.Id);
        workExperienceDTO.CompanyName.Should().Be(workExperience.CompanyName);
    }

    [Fact()]
    public void CreateMap_ForCreateWorkExperienceCommand_MapsCorrectly()
    {
        // Arrange
        var command = new CreateWorkExperienceCommand()
        {
            Name = "Senior Software Engineer",
            CompanyName = "AMCS",
            Description = "Ben is favored",
            TechStack = ["Angular", "C#", "SQL"],
            IsCurrentCompany = true,
            Street = "Balatas Street",
            City = "Las Pinas",
            Country = "Philippines",
            PostalCode = "1740",
            Responsibilities = ["1", "2", "3", "4"],
        };

        // Act
        var workExperience = _mapper.Map<WorkExperience>(command);

        // Assert
        workExperience.Should().NotBeNull();
        workExperience.Name.Should().Be(command.Name);
        workExperience!.Address!.Country.Should().Be(command.Country);
    }
}