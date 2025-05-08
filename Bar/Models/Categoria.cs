using Bar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Models
{
        public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Prodotto> Prodotti { get; set; }
    }
}
