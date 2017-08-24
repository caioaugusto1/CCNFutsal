using ColaComNois.Context.DB;

namespace ColaComNois.Repository.Interfaces
{
    public interface ILoginRepository
    {
        ccn_logins AutenticarAcesso(string email, string senha);
    }
}
