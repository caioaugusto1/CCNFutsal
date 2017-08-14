using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Jogadores, ccn_jogadores>();
            CreateMap<Despesas, ccn_despesas>(); 
            CreateMap<Rateio, ccn_rateios>();
            CreateMap<Login, ccn_logins>(); 
            CreateMap<Jogos, ccn_jogos>(); 
            CreateMap<Adversarios, ccn_adversarios>(); 
        }
    }
}