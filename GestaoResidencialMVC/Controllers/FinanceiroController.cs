using GestaoResidencialMVC.Data;
using GestaoResidencialMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoResidencialMVC.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly ConexaoBanco _context;

        public FinanceiroController(ConexaoBanco context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lancamnetos = _context.Lancamentos.ToList();

            ViewBag.TotalReceitas = lancamnetos.Where(x => x.Tipo == "Receita").Sum(x => x.Valor);

            ViewBag.TotalDespesas = lancamnetos.Where(x => x.Tipo == "Despesa").Sum(x => x.Valor);

            ViewBag.Saldo = ViewBag.TotalReceitas - ViewBag.TotalDespesas;


            return View(lancamnetos);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                _context.Lancamentos.Add(lancamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }          
            return View(lancamento);
        }

       
        public IActionResult Delete(int id)
        {
            var lancamento = _context.Lancamentos.FirstOrDefault(x=> x.Id == id);
            if (lancamento == null) NotFound();
            
            return View(lancamento);
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var lancamento = _context.Lancamentos.FirstOrDefault(x => x.Id == id);
            if (lancamento !=null)
            {
                _context.Lancamentos.Remove(lancamento);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
