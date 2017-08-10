using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColaComNois.Controllers
{
    public class ErroController : Controller
    {
        // GET: Erro
        public ActionResult Index(int? code)
        {
            return View("Error");
        }
    }
}