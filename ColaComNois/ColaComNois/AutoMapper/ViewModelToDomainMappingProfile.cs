using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;

namespace ColaComNois.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Jogadores, CCN_Jogadores>();
            CreateMap<Despesas, CCN_Despesas>(); 
            CreateMap<Rateio, CCN_Rateios>();
            CreateMap<Login, CCN_Logins>(); 
            CreateMap<Jogos, CCN_Jogos>(); 
            CreateMap<Adversarios, CCN_Adversarios>(); 
        }
    }
}