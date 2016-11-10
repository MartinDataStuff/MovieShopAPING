using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    public  abstract class AbsstractEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}
