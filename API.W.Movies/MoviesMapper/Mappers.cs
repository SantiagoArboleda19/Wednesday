using API.W.Movies.DataAccessLayer.Models;
using API.W.Movies.DataAccessLayer.Models.Dtos;
using AutoMapper;

namespace API.W.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
