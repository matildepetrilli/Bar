using Bar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Models
{
    public class CarrelloItem
    {
        public Prodotto Prodotto { get; set; }
        public int Quantita { get; set; } = 1;
    }
}
