using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Contexts;
using System.Data.Entity;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Managers
{
    internal class MovieRepository : IRepository<Movie>
    {
        public Movie Create(Movie o)
        {
            using (var db = new MovieShopContext())
            {
                if (db.Movies == null)
                    return null;
                db.Movies.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Movie> ReadAll()
        {
            using (var db = new MovieShopContext())
            {
                if (db.Movies != null)
                    return db.Movies.Include(movie => movie.Genres).Include(movie => movie.Orders).ToList();
                return new List<Movie>();
            }
        }

        public Movie Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Movies.Include("Genres").Include("Orders").FirstOrDefault(movie => movie.Id == id);
            }
        }

        public Movie Update(Movie o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Movie o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.SaveChanges();
                return Read(o.Id) == null;
            }
        }
    }
}
