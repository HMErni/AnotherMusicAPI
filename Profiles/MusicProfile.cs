using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles
{

    public class MusicProfile : Profile
    {

        public MusicProfile()
        {
            CreateMap<Music, MusicReadDTO>();
            CreateMap<MusicCreateDTO, Music>()
                .ForMember(dest => dest.Genre,
                    opt => opt.Ignore());
        }
    }
}