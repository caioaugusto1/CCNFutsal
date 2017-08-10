using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.CreateMap<CCN_Jogadores, Jogadores>();
            base.CreateMap<CCN_Despesas, Despesas>();
            base.CreateMap<CCN_Rateios, Rateio>();
            base.CreateMap<CCN_Logins, Login>();
            base.CreateMap<CCN_Jogos, Jogos>();
            base.CreateMap<CCN_Adversarios, Adversarios>();
        }
    }
}