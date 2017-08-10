using ColaComNois.Entidades;
using System.Web;

namespace ColaComNois.Filters
{
    public class SessionManager
    {
        public static Login UsuarioLogado
        {
            set
            {

                HttpContext.Current.Session.Add("UsuarioLogado", value);
            }
            get
            {
                return (Login)HttpContext.Current.Session["UsuarioLogado"];
            }

        }

        public static bool IsAuthenticated
        {
            get
            {
                return ((Login)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}