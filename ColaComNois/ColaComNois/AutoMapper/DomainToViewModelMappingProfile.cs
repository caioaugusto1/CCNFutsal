using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CCN_Jogadores, Jogadores>();
            CreateMap<CCN_Despesas, Despesas>();
            CreateMap<CCN_Rateios, Rateio>();
            CreateMap<CCN_Logins, Login>();
            CreateMap<CCN_Jogos, Jogos>();
            CreateMap<CCN_Adversarios, Adversarios>();
        }
    }
}