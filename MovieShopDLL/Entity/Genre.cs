using System.Collections.Generic;

namespace MovieShopDLL.Entity
{
    public class Genre : AbsstractEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
