using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    [Table("Orders")]
    public class Order : AbsstractEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public List<Movie> Movies { get; set; } = new List<Movie>();

        [ForeignKey("Customers")]
        public int CustomersId { get; set; }
        public Customer Customers { get; set; }
    }
}
