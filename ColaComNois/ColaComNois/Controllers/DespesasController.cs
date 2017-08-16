using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;
using ColaComNois.Filters;
using ColaComNois.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ColaComNois.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo")]
    public class DespesasController : Controller
    {
        private DespesasRepository _despesasRepo;

        public DespesasController(DespesasRepository _despesasRepo)
        {
            this._despesasRepo = _despesasRepo;
        }

        [Route("listar-despesas")]
        public ActionResult Index()
        {
            var despesasViewModel = Mapper.Map<IList<ccn_despesas>, IList<Despesas>>(_despesasRepo.ObterTodos());
            return View(despesasViewModel);
        }

        [Route("{id:int}/detalhe-despesa")]
        public ActionResult Details(int id)
        {
            var despesaPorId = _despesasRepo.ObterPorId(id);
            var despesasVieModel = Mapper.Map<ccn_despesas, Despesas>(despesaPorId);

            return View(despesasVieModel);
        }

        [Route("cadastrar-despesa")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Despesas despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<ccn_despesas>(despesa);
                _despesasRepo.Adicionar(despesaDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(despesa);
            }
        }

        [Route("{id:int}/editar-despesa")]
        public ActionResult Edit(int id)
        {
            var despesaPorId = _despesasRepo.ObterPorId(id);
            var despesaViewModel = Mapper.Map<ccn_despesas, Despesas>(despesaPorId);

            return View(despesaViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Despesas despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<Despesas, ccn_despesas>(despesa);
                _despesasRepo.Editar(despesaDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(despesa);
            }
        }

        [Route("{id:int}/deletar-despesa")]
        public ActionResult Delete(int id)
        {
            var despesa = _despesasRepo.ObterPorId(id);
            var despesaViewModel = Mapper.Map<ccn_despesas, Despesas>(despesa);

            return View(despesaViewModel);
        }

        [HttpPost]
        public ActionResult Delete(Despesas despesa)
        {
            var despesaDomain = Mapper.Map<Despesas, ccn_despesas>(despesa);
            _despesasRepo.Excluir(despesaDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
