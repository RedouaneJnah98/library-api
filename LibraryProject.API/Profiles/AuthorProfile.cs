using AutoMapper;
using LibraryProject.API.Entities;
using LibraryProject.API.Helpers;
using LibraryProject.API.Models;

namespace LibraryProject.API.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

        CreateMap<AuthorForCreationDto, Author>();
    }
}