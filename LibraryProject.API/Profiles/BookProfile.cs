using AutoMapper;
using LibraryProject.API.Entities;
using LibraryProject.API.Models;

namespace LibraryProject.API.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookForCreationDto, Book>();
    }
}