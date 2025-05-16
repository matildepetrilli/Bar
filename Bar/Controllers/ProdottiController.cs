using Bar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bar.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly BarContext _context;

        public ProdottiController(BarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorieConProdotti = _context.Categorie
                .Include(c => c.Prodotti)
                .ToList();

            return View(categorieConProdotti);
        }
    }
}
