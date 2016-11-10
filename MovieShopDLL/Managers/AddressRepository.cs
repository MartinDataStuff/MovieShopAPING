using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Contexts;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Managers
{
    class AddressRepository : IRepository<Addresses>
    {

        public Addresses Create(Addresses o)
        {
            using (var db = new MovieShopContext())
            {
                if (db.Addresses == null)
                    return null;
                db.Addresses.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Addresses> ReadAll()
        {
            using (var db = new MovieShopContext())
            {
                if (db.Addresses != null)
                    return db.Addresses.ToList();
                return new List<Addresses>();
            }
        }

        public Addresses Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Addresses.FirstOrDefault(address => address.Id == id);
            }
        }

        public Addresses Update(Addresses o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Addresses o)
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
