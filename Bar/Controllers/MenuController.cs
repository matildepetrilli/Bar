using Bar.Context;
using Bar.Data;
using Bar.Extensions;
using Bar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bar.Controllers
{

    public class MenuController : Controller
    {
        private readonly AppDbContext _db;

        public MenuController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categorie = _db.Categorie.Include(c => c.Prodotti).ToList();
            return View(categorie);
        }

        public IActionResult Index()
        {
            ViewBag.CarrelloCount = HttpContext.Session.Get<List<CarrelloItem>>("Carrello")?.Count ?? 0;
            var categorie = _db.Categorie.Include(c => c.Prodotti).ToList();
            return View(categorie);
        }

        [HttpPost]
        public IActionResult AggiungiAlCarrello(int id)
        {
            var prodotto = _db.Prodotti.Find(id);
            if (prodotto == null) return NotFound();

            var carrello = HttpContext.Session.Get<List<CarrelloItem>>("Carrello") ?? new List<CarrelloItem>();

            var item = carrello.FirstOrDefault(i => i.Prodotto.Id == id);
            if (item != null) item.Quantita++;
            else carrello.Add(new CarrelloItem { Prodotto = prodotto });

            HttpContext.Session.Set("Carrello", carrello);

            TempData["Messaggio"] = $"{prodotto.Nome} aggiunto al carrello!";
            return RedirectToAction("Index");
        }

        public IActionResult Carrello()
        {
            var carrello = HttpContext.Session.Get<List<CarrelloItem>>("Carrello") ?? new List<CarrelloItem>();
            return View(carrello);
        }
    }
}