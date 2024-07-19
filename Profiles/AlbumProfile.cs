using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            // Source => Destination
            CreateMap<Album, AlbumReadDTO>();
            CreateMap<AlbumCreateDTO, Album>()
                .ForMember(dest => dest.Musics,
                    opt => opt.Ignore());
            CreateMap<AlbumUpdateDTO, Album>()
                .ForMember(dest => dest.Musics,
                    opt => opt.Ignore());
        }
    }
}