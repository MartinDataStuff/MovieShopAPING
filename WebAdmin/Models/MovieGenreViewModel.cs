using System.Collections.Generic;
using MovieShopBE;

namespace WebAdmin.Models
{
    public class MovieGenreViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre>  Genres { get; set; } = new List<Genre>();
    }
}
