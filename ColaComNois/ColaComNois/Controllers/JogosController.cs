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
    public class JogosController : Controller
    {
        private JogosRepository _jogosRepo;
        private AdversariosRepository _adversarioRepo;
        public JogosController(JogosRepository _jogosRepo, AdversariosRepository _adversarioRepo)
        {
            this._jogosRepo = _jogosRepo;
            this._adversarioRepo = _adversarioRepo;
        }

        public ActionResult Index()
        {
            var jogosViewModel = Mapper.Map<IList<CCN_Jogos>, IList<Jogos>>(_jogosRepo.ObterTodos());
            return View(jogosViewModel);
        }

        public ActionResult Details(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<CCN_Jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.Adversarios = _adversarioRepo.ObterTodos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jogos jogo)
        {
            if (ModelState.IsValid)
            {
                var jogoDomain = Mapper.Map<CCN_Jogos>(jogo);
                _jogosRepo.Adicionar(jogoDomain);

                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        public ActionResult Edit(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<CCN_Jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Jogos jogo)
        {
            if (ModelState.IsValid)
            {
                var jogoDomain = Mapper.Map<Jogos, CCN_Jogos>(jogo);
                _jogosRepo.Editar(jogoDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(jogo);
            }
        }

        public ActionResult Delete(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<CCN_Jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        [HttpPost]
        public ActionResult Delete(Jogos jogo)
        {
            var jogoDomain = Mapper.Map<Jogos, CCN_Jogos>(jogo);
            _jogosRepo.Excluir(jogoDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
