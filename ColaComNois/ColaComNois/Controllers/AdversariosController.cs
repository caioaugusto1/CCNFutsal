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
    public class AdversariosController : Controller
    {
        private AdversariosRepository _adversarioRepo;
        public AdversariosController(AdversariosRepository _adversarioRepo)
        {
            this._adversarioRepo = _adversarioRepo;
        }

        public ActionResult Index()
        {
            var adversarioViewModel = Mapper.Map<IList<ccn_adversarios>, IList<Adversarios>>(_adversarioRepo.ObterTodos());
            return View(adversarioViewModel);
        }

        public ActionResult Details(int id)
        {
            var adversarioPorId = _adversarioRepo.ObterPorId(id);
            var adversarioViewModel = Mapper.Map<ccn_adversarios, Adversarios>(adversarioPorId);

            return View(adversarioViewModel);
        }

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
