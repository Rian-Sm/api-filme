using API.Models.Dtos.Filme;
using AutoMapper;
using FilmeAPI.Models;

namespace API.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile() {
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
