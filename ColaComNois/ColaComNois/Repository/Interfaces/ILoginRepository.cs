using ColaComNois.Context.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaComNois.Repository.Interfaces
{
    public interface ILoginRepository
    {
        CCN_Logins AutenticarAcesso(string email, string senha);
    }
}
