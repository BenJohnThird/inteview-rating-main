using AutoMapper;
using InterviewRating.Application.Common;
using InterviewRating.Application.Review.DTOs;
using InterviewRating.Application.WorkExperiences.DTOs;
using InterviewRating.Domain.Entities;
using InterviewRating.Domain.Exceptions;
using InterviewRating.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;


internal class ReviewService(
    IReviewRepository reviewRepository,
    ILogger<ReviewService> logger,
    IMapper mapper
    ) : IReviewService
{
    public async Task<Review> CreateReview(CreateReviewRequestDTO request)
    {
        logger.LogInformation("Creating new review");
        var newReview = mapper.Map<Review>(request);
        var review = await reviewRepository.CreateReview(newReview);
        return review;
    }

    public async Task DeleteReview(int id)
    {
        logger.LogInformation($"Delete review with id of {id}");
        var review = await reviewRepository.GetReview(id);
        if (review is null)
        {
            throw new NotFoundException(nameof(Review), id.ToString());
        }

        await reviewRepository.DeleteReview(review);
    }

    public async Task<Review> GetReviewByGuid(Guid id)
    {
        logger.LogInformation($"Getting Review By Guid {id}");
        var review = await reviewRepository.GetReviewByGuid(id);
        if (review is null)
            throw new NotFoundException(nameof(Review), id.ToString());

        return review;
    }

    public async Task<Review> GetReviewById(int id)
    {
        logger.LogInformation($"Getting Review By Id {id}");
        var review = await reviewRepository.GetReview(id);
        if (review is null)
        {
            throw new NotFoundException(nameof(Review), id.ToString());
        }
        return review;
    }

    public async Task<IEnumerable<Review>> GetReviews()
    {
        logger.LogInformation("Getting all reviews");
        var reviews = await reviewRepository.GetReviews();
        return reviews;
    }
    public async Task<PagedResult<Review>> GetMatchingReviews(PageQueryResponse pageQueryResponse)
    {
        logger.LogInformation("Getting all paginated reviews");
        var (reviews, totalCount) = await reviewRepository.GetPaginatedReviews(pageQueryResponse);

        var pagedResult = new PagedResult<Review>(
            reviews, 
            totalCount, 
            pageQueryResponse.PageSize, 
            pageQueryResponse.PageNumber
            );

        return pagedResult;
    }

    public async Task<Review> UpdateReview(UpdateReviewRequestDTO newReview)
    {
        logger.LogInformation($"Updating Review");
        var mappedReview = mapper.Map<Review>(newReview);
        await reviewRepository.SaveChanges();
        return mappedReview;
    }
}
