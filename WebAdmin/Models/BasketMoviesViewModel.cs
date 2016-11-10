using System.Collections.Generic;
using MovieShopBE;

namespace WebAdmin.Models
{
    public class BasketMoviesViewModel
    {
        public List<Movie> Basket { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
