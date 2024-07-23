using AnotherMusicAPI.DTOs.Playlist;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Playlist, PlaylistReadDTO>();
            CreateMap<PlaylistCreateDTO, Playlist>()
                .ForMember(dest => dest.Musics, opt => opt.Ignore());
            CreateMap<PlaylistUpdateDTO, Playlist>()
                .ForMember(dest => dest.Musics, opt => opt.Ignore());

        }
    }
}