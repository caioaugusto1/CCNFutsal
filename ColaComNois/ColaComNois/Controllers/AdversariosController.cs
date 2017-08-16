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
    [RoutePrefix("administrativo")]
    public class AdversariosController : Controller
    {
        private AdversariosRepository _adversarioRepo;
        public AdversariosController(AdversariosRepository _adversarioRepo)
        {
            this._adversarioRepo = _adversarioRepo;
        }

        [Route("listar-adversarios")]
        public ActionResult Index()
        {
            var adversarioViewModel = Mapper.Map<IList<ccn_adversarios>, IList<Adversarios>>(_adversarioRepo.ObterTodos());
            return View(adversarioViewModel);
        }

        [Route("{id:int}/detalhe-adversario")]
        public ActionResult Details(int id)
        {
            var adversarioPorId = _adversarioRepo.ObterPorId(id);
            var adversarioViewModel = Mapper.Map<ccn_adversarios, Adversarios>(adversarioPorId);

            return View(adversarioViewModel);
        }

        [Route("cadastrar-adversario")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Adversarios adversario)
        {
            if (ModelState.IsValid)
            {
                var adversarioDomain = Mapper.Map<ccn_adversarios>(adversario);
                _adversarioRepo.Adicionar(adversarioDomain);

                return RedirectToAction("Index");
            }

            return View(adversario);
        }

        [Route("{id:int}/editar-adversario")]
        public ActionResult Edit(int id)
        {
            var adversarioPorId = _adversarioRepo.ObterPorId(id);
            var adversarioViewModel = Mapper.Map<ccn_adversarios, Adversarios>(adversarioPorId);

            return View(adversarioViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Adversarios adversario)
        {
            if (ModelState.IsValid)
            {
                var adversarioDomain = Mapper.Map<Adversarios, ccn_adversarios>(adversario);
                _adversarioRepo.Editar(adversarioDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(adversario);
            }
        }

        [Route("{id:int}/deletar-adversario")]
        public ActionResult Delete(int id)
        {
            var adversarioPorId = _adversarioRepo.ObterPorId(id);
            var adversarioViewModel = Mapper.Map<ccn_adversarios, Adversarios>(adversarioPorId);

            return View(adversarioViewModel);
        }

        [HttpPost]
        public ActionResult Delete(Adversarios adversario)
        {
            var adversarioDomain = Mapper.Map<Adversarios, ccn_adversarios>(adversario);
            _adversarioRepo.Excluir(adversarioDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
