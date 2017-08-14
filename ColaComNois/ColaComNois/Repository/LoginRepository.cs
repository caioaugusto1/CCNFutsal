using ColaComNois.Context;
using ColaComNois.Context.DB;
using ColaComNois.Repository.Interfaces;
using System.Linq;

namespace ColaComNois.Repository
{
    public class LoginRepository : RepositoryBase<ccn_logins>, ILoginRepository
    {
        public LoginRepository(ColaComNoisContext context) : base(context)
        {
        }

        public ccn_logins AutenticarAcesso(string email, string senha)
        {
            var validarAcesso = ObterTodos().Where(l => l.Email == email && l.Senha == senha).FirstOrDefault();
            return validarAcesso;
        }
    }
}