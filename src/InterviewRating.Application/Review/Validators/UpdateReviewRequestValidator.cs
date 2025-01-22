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

        RuleFor(dto => dto.CompanyRepresentativeEmail)
            .EmailAddress();
    }
}
