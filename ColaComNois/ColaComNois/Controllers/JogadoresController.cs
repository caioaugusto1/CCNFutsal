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
    public class JogadoresController : Controller
    {
        private JogadoresRepository _jogadoresRepo;
        public JogadoresController(JogadoresRepository _jogadoresRepo)
        {
            this._jogadoresRepo = _jogadoresRepo;
        }

        [Route("listar-jogadores")]
        public ActionResult Index()
        {
            var jogadoresViewModel = Mapper.Map<IList<ccn_jogadores>, IList<Jogadores>>(_jogadoresRepo.ObterTodos());
            return View(jogadoresViewModel);
        }

        [Route("{id:int}/detalhe-jogador")]
        public ActionResult Details(int id)
        {
            var jogadorPorId = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<ccn_jogadores, Jogadores>(jogadorPorId);

            return View(jogadorVieModel);
        }

        [Route("cadastrar-jogador")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jogadores jogador)
        {
            if (ModelState.IsValid)
            {
                var jogadorDomain = Mapper.Map<ccn_jogadores>(jogador);
                _jogadoresRepo.Adicionar(jogadorDomain);

                return RedirectToAction("Index");
            }

            return View(jogador);
        }

        [Route("{id:int}/editar-jogador")]
        public ActionResult Edit(int id)
        {
            var jogadorPorId = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<ccn_jogadores, Jogadores>(jogadorPorId);

            return View(jogadorVieModel);
        }

        [HttpPost]
        public ActionResult Edit(Jogadores jogador)
        {
            if (ModelState.IsValid)
            {
                var jogadorDomain = Mapper.Map<Jogadores, ccn_jogadores>(jogador);
                _jogadoresRepo.Editar(jogadorDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(jogador);
            }
        }

        [Route("{id:int}/deletar-jogador")]
        public ActionResult Delete(int id)
        {
            var jogador = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<ccn_jogadores, Jogadores>(jogador);

            return View(jogadorVieModel);
        }

        [HttpPost]
        public ActionResult Delete(Jogadores jogador)
        {
            var jogadorDomain = Mapper.Map<Jogadores, ccn_jogadores>(jogador);
            _jogadoresRepo.Excluir(jogadorDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
