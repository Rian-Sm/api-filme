using API.Models.Dtos;
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
