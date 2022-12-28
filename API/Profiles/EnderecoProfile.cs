using API.Models;
using API.Models.Dtos.Cinema;
using API.Models.Dtos.Endereco;
using AutoMapper;

namespace API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile() {
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
