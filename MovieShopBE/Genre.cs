﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBE
{
    public class Genre : AbsstractEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
