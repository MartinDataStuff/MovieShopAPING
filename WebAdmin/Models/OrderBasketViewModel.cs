using System.Collections.Generic;
using MovieShopBE;

namespace WebAdmin.Models
{
    public class OrderBasketViewModel
    {
        public Order Order { get; set; }
        public List<Movie> Basket { get; set; }

        public List<string> DisplayBasket
        {
            get
            {
                var displayBasket = new List<string>();
                foreach (var movie in this.Basket)
                {
                    movie.Title += ", ";
                    displayBasket.Add(movie.Title);
                }
                return displayBasket;
            }
        }
    }
}
