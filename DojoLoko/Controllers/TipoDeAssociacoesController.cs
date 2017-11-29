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

            var associacoes = _context.TipodeAssociacao.ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(associacoes);
            return View("ReadOnlyIndex", associacoes);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Detalhes(int id)
        {
            var associacao = _context.TipodeAssociacao.SingleOrDefault(c => c.ID == id);

            if (associacao == null)
                return HttpNotFound();

            return View(associacao);

        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Editar(int id)
        {
            var associacao = _context.TipodeAssociacao.SingleOrDefault(c => c.ID == id);

            if (associacao == null)
                return HttpNotFound();

            var viewModel = new TipodeAssociacaoEditarViewModel
            {
               TipodeAssociacao = associacao
            };

            return View("Editar", viewModel);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Deletar(int id)
        {
            var associacao = _context.TipodeAssociacao.SingleOrDefault(c => c.ID == id);

            if (associacao == null)
                return HttpNotFound();

            _context.TipodeAssociacao.Remove(associacao);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // só será acessada com POST
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Salvar(TipoDeAssociacao associacao) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TipodeAssociacaoEditarViewModel
                {
                    TipodeAssociacao = associacao
                };
                return View("Editar", viewModel);
            }

            if (associacao.ID == 0)
                _context.TipodeAssociacao.Add(associacao);
            else
            {
                var customerInDb = _context.TipodeAssociacao.Single(c => c.ID == associacao.ID);

                customerInDb.Nome = associacao.Nome;
                customerInDb.Mensalidade = associacao.Mensalidade;
                customerInDb.Periodo = associacao.Periodo;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Novo()
        {

            var viewModel = new TipodeAssociacaoEditarViewModel
            {
                TipodeAssociacao = new TipoDeAssociacao()
            };
            return View("Editar", viewModel);

        }
    }
}