using FluentValidation;

namespace InterviewRating.Application.Common;

public class PageQueryResponseValidator : AbstractValidator<PageQueryResponse>
{
    public PageQueryResponseValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .GreaterThanOrEqualTo(1);
    }
}
