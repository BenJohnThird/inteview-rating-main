using FluentValidation;
using InterviewRating.Application.WorkExperiences.DTOs;

namespace InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience;

public class CreateWorkExperienceCommandValidator : AbstractValidator<CreateWorkExperienceCommand>
{
    private readonly HashSet<string> validCountries = new(StringComparer.OrdinalIgnoreCase)
    {
        "Philippines", "USA", "Australia", "Singapore"
    };

    public CreateWorkExperienceCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required");

        RuleFor(dto => dto.CompanyName)
            .MaximumLength(255);

        RuleFor(dto => dto.Country)
            .Must(validCountries.Contains)
            .WithMessage($"Country must be one of these values {string.Join(", ", validCountries)}");

        RuleFor(dto => dto.TechStack)
            .Must(rule => rule.Length >= 1)
            .WithMessage("Tech stack must be filled atleast 1");
    }
}
