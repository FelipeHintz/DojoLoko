using DojoLoko.Models;
using DojoLoko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoLoko.Controllers
{
	public class TipoDeAssociacoesController : Controller
	{
		private ApplicationDbContext _context;

		public TipoDeAssociacoesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{

			var asses = _context.TipodeAssociacao.ToList();

			return View(asses);
		}

		public ActionResult Detalhes(int id)
		{
			var ass = _context.TipodeAssociacao.SingleOrDefault(c => c.ID == id);

			if (ass == null)
				return HttpNotFound();

			return View(ass);

		}
	}
}