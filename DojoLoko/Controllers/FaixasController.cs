using DojoLoko.Models;
using DojoLoko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoLoko.Controllers
{
    public class FaixasController : Controller
    {

        private ApplicationDbContext _context;

        public FaixasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var faixas = _context.Faixa.ToList();

            return View(faixas);
        }

        public ActionResult Detalhes(int id)
        {
            var faixa = _context.Faixa.SingleOrDefault(c => c.ID == id);

            if (faixa == null)
                return HttpNotFound();

            return View(faixa);

        }

	}
}