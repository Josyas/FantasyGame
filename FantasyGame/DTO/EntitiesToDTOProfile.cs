using AutoMapper;
using FantasyGame.Entities;

namespace FantasyGame.DTO
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Partida, PartidaDTO>().ReverseMap();
            CreateMap<TimeFutebol, TimeFutebolDTO>().ReverseMap();
            CreateMap<TimeFutebol, IdTimeFutebolDTO>().ReverseMap();
        }
    }
}
