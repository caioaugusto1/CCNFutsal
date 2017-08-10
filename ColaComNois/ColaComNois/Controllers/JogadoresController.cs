using AutoMapper;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;
using ColaComNois.Filters;
using ColaComNois.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ColaComNois.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo-jogadores")]
    public class JogadoresController : Controller
    {
        private JogadoresRepository _jogadoresRepo;
        public JogadoresController(JogadoresRepository _jogadoresRepo)
        {
            this._jogadoresRepo = _jogadoresRepo;
        }
        [Route("administrativo-listar-jogadores")]
        public ActionResult Index()
        {
            var jogadoresViewModel = Mapper.Map<IList<CCN_Jogadores>, IList<Jogadores>>(_jogadoresRepo.ObterTodos());
            return View(jogadoresViewModel);
        }
        [Route("Details/{id:id}")]
        public ActionResult Details(int id)
        {
            var jogadorPorId = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<CCN_Jogadores, Jogadores>(jogadorPorId);

            return View(jogadorVieModel);
        }
        [Route("administrativo-criar-jogador")]
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
                var jogadorDomain = Mapper.Map<CCN_Jogadores>(jogador);
                _jogadoresRepo.Adicionar(jogadorDomain);

                return RedirectToAction("Index");
            }

            return View(jogador);
        }
        [Route("administrativo-editar-jogador/{id:id}")]
        public ActionResult Edit(int id)
        {
            var jogadorPorId = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<CCN_Jogadores, Jogadores>(jogadorPorId);

            return View(jogadorVieModel);
        }

        [HttpPost]
        public ActionResult Edit(Jogadores jogador)
        {
            if (ModelState.IsValid)
            {
                var jogadorDomain = Mapper.Map<Jogadores, CCN_Jogadores>(jogador);
                _jogadoresRepo.Editar(jogadorDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(jogador);
            }
        }

        public ActionResult Delete(int id)
        {
            var jogador = _jogadoresRepo.ObterPorId(id);
            var jogadorVieModel = Mapper.Map<CCN_Jogadores, Jogadores>(jogador);

            return View(jogadorVieModel);
        }

        [HttpPost]
        public ActionResult Delete(Jogadores jogador)
        {
            var jogadorDomain = Mapper.Map<Jogadores, CCN_Jogadores>(jogador);
            _jogadoresRepo.Excluir(jogadorDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
