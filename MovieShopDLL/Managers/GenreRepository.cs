using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Contexts;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Managers
{
    class GenreRepository : IRepository<Genre>
    {
        public Genre Create(Genre o)
        {
            var temp = ReadAll().FirstOrDefault(genre => genre.Name == o.Name);

            if (temp == null)
                using (var db = new MovieShopContext())
                {
                    if (db.Genres == null)
                        return null;
                    db.Genres.Add(o);
                    db.SaveChanges();
                    return o;
                }

            return temp;
        }

        public List<Genre> ReadAll()
        {
            using (var db = new MovieShopContext())
            {
                if (db.Genres != null)
                    return db.Genres.ToList();
                return new List<Genre>();
            }
        }

        public Genre Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.FirstOrDefault(genre => genre.Id == id);
            }
        }

        public Genre Update(Genre o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Genre o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Read(o.Id) == null;
            }
        }
    }
}
