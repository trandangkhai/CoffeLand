using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace CoffeLand.Models
{
    public class CoffeGenreViewModel
    {
        public List<Coffe>? Coffes { get; set; }
        public SelectList? Genres { get; set; }
        public string? CoffeGenre { get; set; }
        public string? SearchString { get; set; }
    }
}