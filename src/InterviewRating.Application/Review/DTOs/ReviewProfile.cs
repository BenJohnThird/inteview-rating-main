using AutoMapper;
using InterviewRating.Application.Review.DTOs;
using InterviewRating.Domain.Entities;


public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewRequestDTO, Review>();

        CreateMap<UpdateReviewRequestDTO, Review>();
    }
}
