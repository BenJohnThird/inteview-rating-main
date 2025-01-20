using FluentValidation;

namespace InterviewRating.Application.WorkExperiences.Commands.UpdateWorkExperience;

public class UpdateWorkExperienceCommandValidator : AbstractValidator<UpdateWorkExperienceCommand>
{
    public UpdateWorkExperienceCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required");

        RuleFor(dto => dto.CompanyName)
            .MaximumLength(255);

        RuleFor(dto => dto.Responsibilities)
            .Must(rule => rule.Length > 5 && rule.Length < 20)
            .WithMessage("Responsibilities must not be over than 5");

        RuleFor(dto => dto.TechStack)
            .Must(rule => rule.Length >= 1)
            .WithMessage("Tech stack must be filled atleast 1");
    }
}
