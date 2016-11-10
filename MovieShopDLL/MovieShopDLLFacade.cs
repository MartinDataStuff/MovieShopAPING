using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entity;
using MovieShopDLL.Managers;
using Order = MovieShopDLL.Entity.Order;

namespace MovieShopDLL
{
    public class MovieShopDLLFacade
    {
        public IRepository<Addresses> GetAddressRepository()
        {
            return new AddressRepository();
        }

        public IRepository<Customer> GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        public IRepository<Genre> GetGenreRepository()
        {
            return new GenreRepository();
        }

        public IRepository<Movie> GetMovieRepository()
        {
            return new MovieRepository();
        }

        public IRepository<Order> GetOrderRepository()
        {
            return new OrderRepository();
        }
    }
}
