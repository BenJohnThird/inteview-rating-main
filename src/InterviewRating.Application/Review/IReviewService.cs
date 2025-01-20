using InterviewRating.Application.Common;
using InterviewRating.Application.Review.DTOs;
using InterviewRating.Domain.Entities;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetReviews();
    Task<PagedResult<Review>> GetMatchingReviews(PageQueryResponse pageQueryResponse);
    Task<Review> GetReviewById(int id);
    Task<Review> GetReviewByGuid(Guid id);
    Task<Review> CreateReview(CreateReviewRequestDTO newReview);
    Task<Review> UpdateReview(UpdateReviewRequestDTO newReview);
    Task DeleteReview(int id);
}
