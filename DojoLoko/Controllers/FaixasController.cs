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
            if (User.IsInRole("CanManageCustomers"))
                return View(faixas);
            return View("ReadOnlyIndex", faixas);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Detalhes(int id)
        {
            var faixa = _context.Faixa.SingleOrDefault(c => c.ID == id);

            if (faixa == null)
                return HttpNotFound();

            return View(faixa);

        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Editar(int id)
        {
            var faixa = _context.Faixa.SingleOrDefault(c => c.ID == id);

            if (faixa == null)
                return HttpNotFound();

            var viewModel = new FaixaEditarViewModel
            {
                Faixa = faixa
            };

            return View("Editar", viewModel);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Deletar(int id)
        {
            var faixa = _context.Faixa.SingleOrDefault(c => c.ID == id);

            if (faixa == null)
                return HttpNotFound();

            _context.Faixa.Remove(faixa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // só será acessada com POST
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Salvar(Faixa faixa) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FaixaEditarViewModel
                {
                    Faixa = faixa
                };
                return View("Editar", viewModel);
            }

            if (faixa.ID == 0)
                _context.Faixa.Add(faixa);
            else
            {
                var customerInDb = _context.Faixa.Single(c => c.ID == faixa.ID);

                customerInDb.Nome = faixa.Nome;
                customerInDb.Grau = faixa.Grau;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Novo()
        {

            var viewModel = new FaixaEditarViewModel
            {
                Faixa = new Faixa()
            };
            return View("Editar", viewModel);

        }

    }
}