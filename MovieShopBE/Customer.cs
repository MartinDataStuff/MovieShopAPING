using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    [Table("Customers")]
    public class Customer : AbsstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Addresses")]
        public int AddressesId { get; set; }
        public Addresses Addresses { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
