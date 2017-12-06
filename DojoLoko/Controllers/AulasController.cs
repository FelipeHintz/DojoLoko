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
	public class AulasController : Controller
	{
		private ApplicationDbContext _context;

		public AulasController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{
            var aulas = _context.Aula.Include(c => c.Alunos).ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(aulas);
            return View("ReadOnlyIndex", aulas);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Detalhes(int id)
		{
			var aula = _context.Aula.Include(c => c.Alunos).SingleOrDefault(c => c.ID == id);

			if (aula == null)
				return HttpNotFound();

			return View(aula);

		}

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Editar(int id)
		{
            var aula = _context.Aula.Include(c => c.Alunos).SingleOrDefault(c => c.ID == id);

            if (aula == null)
				return HttpNotFound();

            var viewModel = new AulaEditarViewModel
            {
                Aula = aula,
                Aluno = _context.Aluno.ToList()
			};

			return View("Editar", viewModel);
		}

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Deletar(int id)
        {
            var aula = _context.Aula.SingleOrDefault(c => c.ID == id);

            if (aula == null)
                return HttpNotFound();

            _context.Aula.Remove(aula);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // só será acessada com POST
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Salvar(Aula aula) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AulaEditarViewModel
                {
                    Aula = aula,
                    Aluno = _context.Aluno.ToList()
                };
                return View("Editar", viewModel);
            }

            if (aula.ID == 0)
                _context.Aula.Add(aula);
            else
            {
                var customerInDb = _context.Aula.Include(c => c.Alunos).Single(c => c.ID == aula.ID);

                customerInDb.Alunos = aula.Alunos;
                customerInDb.Data = aula.Data;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Novo()
        {

            var viewModel = new AulaEditarViewModel
            { 
                Aula = new Aula(),
                Aluno = _context.Aluno.ToList()
            };
            return View("Editar", viewModel);

        }
	}
}