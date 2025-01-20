using InterviewRating.Application.Common;
using InterviewRating.Domain.Entities;

namespace InterviewRating.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviews();
    Task<(IEnumerable<Review>, int)> GetPaginatedReviews(PageQueryResponse pageQueryResponse);
    Task<Review?> GetReview(int? id);
    Task<Review?> GetReviewByGuid(Guid? id);
    Task<Review> CreateReview(Review newReview);
    Task DeleteReview(Review review);
    Task SaveChanges();
}
