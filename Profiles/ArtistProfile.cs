using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;

namespace AnotherMusicAPI.Profiles{
    public class ArtistProfile : Profile{
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistReadDTO>();
            CreateMap<ArtistCreateDTO, Artist>();
            CreateMap<ArtistUpdateDTO, Artist>();
        }
    }
}