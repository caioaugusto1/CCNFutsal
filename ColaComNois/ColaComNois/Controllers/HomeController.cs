using ColaComNois.Filters;
using ColaComNois.Repository;
using System.Web.Mvc;

namespace ColaComNois.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("pagina-principal")]
    [Route("{action=principal}")]
    public class HomeController : Controller
    {
        private DespesasRepository _despesasRepo;

        public HomeController(DespesasRepository _despesasRepo)
        {
            this._despesasRepo = _despesasRepo;
        }

        [Route("home-princiapl")]
        public ActionResult Index()
        {
            ViewBag.ContarDespesas = _despesasRepo.ObterTodos().Count;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}