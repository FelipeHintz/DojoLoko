using DojoLoko.Models;
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

			var alunos = _context.Aluno.ToList();

			return View(alunos);
		}

		public ActionResult Detalhes(int id)
		{
			var aluno = _context.Aluno.Include(c => c.Faixa).Include(c => c.TipoDeAssociacao).SingleOrDefault(c => c.ID == id);

			if (aluno == null)
				return HttpNotFound();

			return View(aluno);

		}
	}
}