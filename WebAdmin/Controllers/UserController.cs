using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopBE;
using MovieShopDLL;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class UserController : Controller
    {
        readonly IManager<Movie> _manager = new MovieShopDLLFacade().GetMovieManager();
        // GET: User
        public ActionResult Index()
        {
            return View(_manager.ReadAll());
        }


        public ActionResult AddMovie(int id)
        {
            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();
            cart.Movies.Add(_manager.Read(id));
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}