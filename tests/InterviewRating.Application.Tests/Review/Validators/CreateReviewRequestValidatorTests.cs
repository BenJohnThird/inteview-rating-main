using FluentValidation.TestHelper;
using InterviewRating.Application.Review.DTOs;
using Xunit;

namespace InterviewRating.Application.Review.Validators.Tests
{
    public class CreateReviewRequestValidatorTests
    {
        [Fact()]
        public void Validator_ForValidDTO_ShouldNotHaveAnyValidationErrors()
        {
            // Arrange
            var requestDTO = new CreateReviewRequestDTO()
            {
                CompanyName = "AMCS",
                CompanyRepresentativeEmail = "ben.villanueva@amcs.com",
                CompanyRepresentativeName = "Ben Villanueva",
                Feedback = "This should be atleast 50 characters long. This should be nice."
            };
            var validator = new CreateReviewRequestValidator();

            // Act
            var result = validator.TestValidate(requestDTO);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validator_ForInValidDTO_ShouldHaveAnyValidationErrors()
        {
            // Arrange
            var requestDTO = new CreateReviewRequestDTO()
            {
                CompanyName = "AMCS",
                CompanyRepresentativeEmail = "ben.villanueva@amcs.com",
                CompanyRepresentativeName = "Ben Villanueva",
                Feedback = "This should be atleast 50 characters long"
            };
            var validator = new CreateReviewRequestValidator();

            // Act
            var result = validator.TestValidate(requestDTO);

            // Assert
            result.ShouldHaveValidationErrorFor(column => column.Feedback);
        }
    }
}