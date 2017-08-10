using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.CrossCounting;
using ColaComNois.Entidades;
using ColaComNois.Filters;
using ColaComNois.Repository;
using System.Web.Mvc;

namespace ColaComNois.Controllers
{
    [RoutePrefix("cola-com-nois-login")]
    public class LoginController : Controller
    {
        private LoginRepository _loginRepo;
        public LoginController(LoginRepository _loginRepo)
        {
            this._loginRepo = _loginRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string email, string senha)
        {
            ViewBag.Error = true;

            if (ModelState.IsValid)
            {
                var senhaCripto = Criptografia.CriptografaMd5(senha);

                var validarAcesso = _loginRepo.AutenticarAcesso(email, senhaCripto);

                if (validarAcesso == null)
                {
                    ModelState.AddModelError("login.Invalido", "Usuário ou senha Inválido, tente novamente!");
                }
                else
                {
                    ViewBag.Error = false;
                    SessionManager.UsuarioLogado = Mapper.Map<CCN_Logins, Login>(validarAcesso);
                    System.Web.Security.FormsAuthentication.SetAuthCookie(validarAcesso.Email, true);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Preencha o campo com login e senha!");
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return View("Index");
        }
    }
}