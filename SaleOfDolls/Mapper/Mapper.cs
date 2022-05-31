using AutoMapper;
using SaleOfDolls.DTO;
using SaleOfDolls.Models;

namespace SaleOfDolls.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddressDTO, Address>();
            CreateMap<ClientDTO, Client>();
            CreateMap<DollDTO, Doll>();
            CreateMap<SolicitationDTO, Solicitation>();
        }
    }
}