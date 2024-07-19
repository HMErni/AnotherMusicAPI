using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles
{

    public class MusicProfile : Profile
    {

        public MusicProfile()
        {
            // Source => Destination
            CreateMap<Music, MusicReadDTO>();
            CreateMap<MusicCreateDTO, Music>()
                .ForMember(dest => dest.Genre,
                    opt => opt.Ignore())
                .ForMember(dest => dest.Artists,
                    opt => opt.Ignore());
            CreateMap<MusicUpdateDTO, Music>()
                .ForMember(dest => dest.Artists,
                    opt => opt.Ignore());
        }
    }
}