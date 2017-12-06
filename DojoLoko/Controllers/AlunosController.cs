using DojoLoko.Models;
using DojoLoko.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoLoko.Controllers
{
	public class AlunosController : Controller
	{
		private ApplicationDbContext _context;

		public AlunosController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{
            var alunos = _context.Aluno.Include(c => c.Faixa).Include(c => c.TipoDeAssociacao).ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(alunos);
            return View("ReadOnlyIndex", alunos);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Detalhes(int id)
		{
			var aluno = _context.Aluno.Include(c => c.Faixa).Include(c => c.TipoDeAssociacao).Include(c => c.Aulas).SingleOrDefault(c => c.ID == id);

			if (aluno == null)
				return HttpNotFound();

			return View(aluno);

		}

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Editar(int id)
		{
			var aluno = _context.Aluno.Include(c => c.Faixa).Include(c => c.TipoDeAssociacao).Include(c => c.Aulas).SingleOrDefault(c => c.ID == id);

			if (aluno == null)
				return HttpNotFound();

			var viewModel = new AlunoEditarViewModel
			{
                Aluno = aluno,
                Faixa = _context.Faixa.ToList(),
                TipoDeAssociacao = _context.TipodeAssociacao.ToList(),
                Aula = _context.Aula.ToList()
            };

			return View("Editar", viewModel);
		}

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Deletar(int id)
        {
            var aluno = _context.Aluno.Include(c => c.Faixa).Include(c => c.TipoDeAssociacao).Include(c => c.Aulas).SingleOrDefault(c => c.ID == id);

            if (aluno == null)
                return HttpNotFound();

            _context.Aluno.Remove(aluno);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // só será acessada com POST
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Salvar(Aluno aluno) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AlunoEditarViewModel
                {
                    Aluno = aluno,
                    Faixa = _context.Faixa.ToList(),
                    TipoDeAssociacao = _context.TipodeAssociacao.ToList(),
                    Aula = _context.Aula.ToList()
                };
                return View("Editar", viewModel);
            }

            if (aluno.ID == 0)
                _context.Aluno.Add(aluno);
            else
            {
                var customerInDb = _context.Aluno.Include(m => m.Aulas).Single(c => c.ID == aluno.ID);

                customerInDb.Nome = aluno.Nome;
                customerInDb.CPF = aluno.CPF;
                customerInDb.TipodeAssociacaoId = aluno.TipodeAssociacaoId;
                customerInDb.FaixaId = aluno.FaixaId;
                customerInDb.Aulas = aluno.Aulas;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Novo()
        {

            var viewModel = new AlunoEditarViewModel
            { 
                Aluno = new Aluno(),
                Faixa = _context.Faixa.ToList(),
                TipoDeAssociacao = _context.TipodeAssociacao.ToList(),
                Aula = _context.Aula.ToList()
            };
            return View("Editar", viewModel);

        }
	}
}