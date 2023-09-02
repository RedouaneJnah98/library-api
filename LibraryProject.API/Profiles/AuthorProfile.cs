using AutoMapper;
using LibraryProject.API.Entities;
using LibraryProject.API.Models;

namespace LibraryProject.API.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorForCreationDto, Author>();
    }
}