using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Contexts;
using System.Data.Entity;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Managers
{
    class OrderRepository : IRepository<Order>
    {
        public Order Create(Order o)
        {
            using (var db = new MovieShopContext())
            {
                if (db.Orders == null)
                    return null;

                o.Customers = db.Customers.Include(x => x.Addresses).FirstOrDefault(x => x.Id == o.Customers.Id);

                var tmpList = new List<Movie>();

                foreach (var movie in o.Movies)
                {
                    tmpList.Add(db.Movies.Include("Genres").Include("Orders").FirstOrDefault(_movie => _movie.Id == movie.Id));
                }

                o.Movies = tmpList;

                db.Orders.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Order> ReadAll()
        {
            using (var db = new MovieShopContext())
            {
                if (db.Orders != null)
                    return db.Orders.Include(order => order.Customers).Include(order => order.Movies).ToList();
                return new List<Order>();
            }
        }

        public Order Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Orders.Include("Customers").Include("Movies").FirstOrDefault(order => order.Id == id);
            }
        }

        public Order Update(Order o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Order o)
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

