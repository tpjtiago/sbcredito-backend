using AutoMapper;
using SBcredito.Domain.Entities;
using SBcredito.Domain.Models;

namespace SBcredito.Domain.AutoMapper
{
    public class TituloAnaliseProfile : Profile
    {
        public TituloAnaliseProfile()
        {
            CreateMap<TituloAnaliseModel, TituloAnalise>().ReverseMap();
        }
    }
}
