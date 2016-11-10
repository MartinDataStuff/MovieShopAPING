using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entity;

namespace MovieShopDLL.Contexts
{
    class MovieShopContext : DbContext
    {
        public MovieShopContext() : base("name=MovieShop")
        {
            //Database.SetInitializer(new DatabaseInitializer());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MovieShopContext>());
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Addresses> Addresses { get; set; }


    }

    class DatabaseInitializer : DropCreateDatabaseAlways<MovieShopContext>
    {
        protected override void Seed(MovieShopContext context)
        {
            var genre1 = context.Genres.Add(new Genre() { Name = "Comedy" });
            var genre2 = context.Genres.Add(new Genre() { Name = "Horror" });
            var movie1 = context.Movies.Add(new Movie
            {
                Genres = genre1,
                Title = "Movie1",
                ImageUrl = "http://imageservice.nordjyske.dk/images/nordjyske.story/2015_10_22/afea37d2-a25b-40a6-b5cd-80f9fcfc0f5b.jpg?w=839&h=559&mode=crop&scale=both",
                Price = 1000,
                Year = DateTime.Now
            });

            var movie2 = context.Movies.Add(new Movie
            {
                Genres = genre2,
                Title = "New Movie",
                ImageUrl = "http://fniis.dk/billeder/49af8c19f4c78cc10fd7a46a3cf8a2a7.jpg",
                Price = 500,
                Year = DateTime.Now.AddYears(-7)
            });
            var movie3 = context.Movies.Add(
                new Movie
                {
                    Genres = genre1,
                    Title = "American History X",
                    ImageUrl = "http://www.gstatic.com/tv/thumb/movieposters/21980/p21980_p_v8_ae.jpg",
                    Price = 1488,
                    Year = DateTime.Now.AddYears(-7)
                });
            var address = context.Addresses.Add(new Addresses
            {
                Country = "New Land",
                Street = "A Street 123",
                ZipCode = "6600"
            });

            var customer = context.Customers.Add(new Customer
            {
                FirstName = "First",
                LastName = "Last",
                Email = "a@b.c",
                PhoneNr = "22351315",
                Addresses = address
            });

            var movieList = new List<Movie>();
            movieList.Add(movie1);
            movieList.Add(movie2);

            context.Orders.Add(new Order
            {
                Customers = customer,
                Movies = movieList
            });
            base.Seed(context);
        }
    }
}
