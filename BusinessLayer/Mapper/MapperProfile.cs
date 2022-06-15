using AutoMapper;
using Safe_Development.BusinessLayer.DTOs;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.BusinessLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DebitCard, DebitCardDTO>();
        }
    }
}
