using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ccn_jogadores, Jogadores>();
            CreateMap<ccn_despesas, Despesas>();
            CreateMap<ccn_rateios, Rateio>();
            CreateMap<ccn_logins, Login>();
            CreateMap<ccn_jogos, Jogos>();
            CreateMap<ccn_adversarios, Adversarios>();
        }
    }
}