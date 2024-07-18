using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreReadDTO>();
            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();
        }
    }
}