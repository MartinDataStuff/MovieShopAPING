using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBE;

namespace WebAdmin.Models
{
    class ShoppingCart
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
