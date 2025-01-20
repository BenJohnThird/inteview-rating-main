using AutoMapper;
using InterviewRating.Application.WorkExperiences.Commands.CreateWorkExperience;
using InterviewRating.Application.WorkExperiences.Commands.UpdateWorkExperience;
using InterviewRating.Domain.Entities;

namespace InterviewRating.Application.WorkExperiences.DTOs;

public class WorkExperiencesProfile : Profile
{
    public WorkExperiencesProfile()
    {
        CreateMap<WorkExperience, WorkExperiencesDTO>()
            .ForMember(d => d.City, opt =>
            {
                opt.MapFrom(src => src.Address == null ? null : src.Address.City);
            })
            .ForMember(d => d.PostalCode, opt =>
            {
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode);
            })
            .ForMember(d => d.Street, opt =>
            {
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street);
            })
            .ForMember(d => d.Country, opt =>
            {
                opt.MapFrom(src => src.Address == null ? null : src.Address.Country);
            });

        CreateMap<CreateWorkExperienceCommand, WorkExperience>()
            .ForMember(dest => dest.Address, opt =>
            {
                opt.MapFrom(src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                    Country = src.Country,
                });
            });

        CreateMap<UpdateWorkExperienceCommand, WorkExperience>()
            .ForMember(dest => dest.Address, opt =>
            {
                opt.MapFrom(src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                    Country = src.Country,
                });
            });
    }
}
