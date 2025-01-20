using FluentValidation;
using InterviewRating.Application.Review.DTOs;

namespace InterviewRating.Application.Review.Validators;

public class UpdateReviewRequestValidator : AbstractValidator<UpdateReviewRequestDTO>
{
    public UpdateReviewRequestValidator()
    {
        RuleFor(dto => dto.CompanyRepresentativeName)
            .Length(3, 255);

        RuleFor(dto => dto.CompanyName)
            .Length(3, 255);

        RuleFor(dto => dto.Feedback)
            .Length(50, 255)
            .WithMessage("Feedback must be at least 50 characters long");

        RuleFor(dto => dto.CompanyRepresentativeEmail)
            .EmailAddress();
    }
}
