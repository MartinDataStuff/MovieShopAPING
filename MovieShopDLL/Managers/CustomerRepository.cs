using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Contexts;
using System.Data.Entity;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Managers
{
    class CustomerRepository : IRepository<Customer>
    {

        public Customer Create(Customer o)
        {
            using (var db = new MovieShopContext())
            {
                if (db.Customers == null)
                    return null;
                db.Customers.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Customer> ReadAll()
        {
            using (var db = new MovieShopContext())
            {
                if (db.Customers != null)
                    return db.Customers.Include(customer => customer.Addresses).ToList();
                return new List<Customer>();
            }
        }

        public Customer Read(int id)
        {
            using (var db = new MovieShopContext())
            {
               return db.Customers.Include("Addresses").FirstOrDefault(customer => customer.Id == id);
            }
        }

        public Customer Update(Customer o)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Customer o)
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
