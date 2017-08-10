using ColaComNois.Context.DB;
using ColaComNois.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColaComNois.Context;

namespace ColaComNois.Repository
{
    public class LoginRepository : RepositoryBase<CCN_Logins>, ILoginRepository
    {
        public LoginRepository(ColaComNoisContext context) : base(context)
        {
        }

        public CCN_Logins AutenticarAcesso(string email, string senha)
        {
            var validarAcesso = ObterTodos().Where(l => l.Email == email && l.Senha == senha).FirstOrDefault();
            return validarAcesso;
        }
    }
}