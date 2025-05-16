using Bar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Models
{
        public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public List<Prodotto> Prodotti { get; set; }
    }
}
