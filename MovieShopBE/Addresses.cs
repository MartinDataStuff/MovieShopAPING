using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    public class Addresses : AbsstractEntity
    {
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string DisplayName => this.Street + " " + this.Country +" "+ this.ZipCode;
    }
}
