using API.Models;
using API.Models.Dtos.Cinema;
using API.Models.Dtos.Filme;
using AutoMapper;

namespace API.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
