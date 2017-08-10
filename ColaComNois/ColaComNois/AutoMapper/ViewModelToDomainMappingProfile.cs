using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.CreateMap<Jogadores, CCN_Jogadores>();
            base.CreateMap<Despesas, CCN_Despesas>(); 
            base.CreateMap<Rateio, CCN_Rateios>();
            base.CreateMap<Login, CCN_Logins>(); 
            base.CreateMap<Jogos, CCN_Jogos>(); 
            base.CreateMap<Adversarios, CCN_Adversarios>(); 
        }
    }
}