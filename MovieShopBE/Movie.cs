using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    [Table("Movies")]
    public class Movie : AbsstractEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        [ForeignKey("Genres")]
        public int GenresId { get; set; }
        public Genre Genres { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
