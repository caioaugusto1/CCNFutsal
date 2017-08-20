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
    public class JogosController : Controller
    {
        private JogosRepository _jogosRepo;
        private AdversariosRepository _adversarioRepo;
        public JogosController(JogosRepository _jogosRepo, AdversariosRepository _adversarioRepo)
        {
            this._jogosRepo = _jogosRepo;
            this._adversarioRepo = _adversarioRepo;
        }

        [Route("listar-jogos")]
        public ActionResult Index()
        {
            var jogosViewModel = Mapper.Map<IList<ccn_jogos>, IList<Jogos>>(_jogosRepo.ObterTodos());
            return View(jogosViewModel);
        }

        [Route("{id:int}/detalhe-jogos")]
        public ActionResult Details(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<ccn_jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        [Route("cadastrar-jogo")]
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
                var jogoDomain = Mapper.Map<ccn_jogos>(jogo);
                _jogosRepo.Adicionar(jogoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.Adversarios = _adversarioRepo.ObterTodos();

            return View(jogo);
        }

        [Route("{id:int}/editar-jogo")]
        public ActionResult Edit(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<ccn_jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Jogos jogo)
        {
            if (ModelState.IsValid)
            {
                var jogoDomain = Mapper.Map<Jogos, ccn_jogos>(jogo);
                _jogosRepo.Editar(jogoDomain);

                return RedirectToAction("Index");
            }
            else
            {
                return View(jogo);
            }
        }

        [Route("{id:int}/deletar-jogo")]
        public ActionResult Delete(int id)
        {
            var jogoPorId = _jogosRepo.ObterPorId(id);
            var jogoViewModel = Mapper.Map<ccn_jogos, Jogos>(jogoPorId);

            return View(jogoViewModel);
        }

        [HttpPost]
        public ActionResult Delete(Jogos jogo)
        {
            var jogoDomain = Mapper.Map<Jogos, ccn_jogos>(jogo);
            _jogosRepo.Excluir(jogoDomain.Id);

            return RedirectToAction("Index");
        }
    }
}
