using InterviewRating.Application.Common;
using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Repositories;
using InterviewRating.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterviewRating.Infrastructure.Repositories;

internal class ReviewRepository(InterviewRatingDbContext dbContext) : IReviewRepository
{
    public async Task<Review> CreateReview(Review newReview)
    {
        dbContext.Reviews.Add(newReview);
        await dbContext.SaveChangesAsync();
        return newReview;
    }

    public async Task DeleteReview(Review review)
    {
        dbContext.Remove(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Review>, int)> GetPaginatedReviews(PageQueryResponse query)
    {
        var searchTermLower = query.SearchTerm?.ToLower();

        var baseQuery = dbContext
            .Reviews
            .Where(r => searchTermLower == null || (r.CompanyName.ToLower().Contains(searchTermLower)));

        var totalCount = await baseQuery.CountAsync();

        if (query.SortBy != null)
        {
            var columnSelector = new Dictionary<string, Expression<Func<Review, object>>>
            {
                { nameof(Review.CompanyName), r => r.CompanyName },
                { nameof(Review.CompanyRepresentativeName), r => r.CompanyRepresentativeName },
            };

            var selectedColumn = columnSelector[query.SortBy];

            baseQuery = query.SortDirection == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);
        }

        var reviews = await baseQuery
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToListAsync();

        return (reviews, totalCount);
    }

    public async Task<Review?> GetReview(int? id)
    {
        var review = await dbContext.Reviews.FindAsync(id);
        return review;
    }

    public async Task<Review?> GetReviewByGuid(Guid? id)
    {
        var review = await dbContext.Reviews.FirstOrDefaultAsync(review => review.SpecialId == id);
        return review;
    }

    public async Task<IEnumerable<Review>> GetReviews()
    {
        var reviews = await dbContext.Reviews.ToListAsync();
        return reviews;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
