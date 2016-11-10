using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopBE;
using MovieShopDLL;
using MovieShopDLL.Contexts;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IManager<Order> _manager = new MovieShopDLLFacade().GetOrderManager();

        private readonly IManager<Customer> _custManager= new MovieShopDLLFacade().GetCustomerManager();

        // GET: Orders
        public ActionResult Index()
        {
            return View(_manager.ReadAll());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _manager.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();
            Session["cart"] = cart;
            var viewModel = new OrderBasketViewModel
            {
                Basket = cart.Movies
            };
            return View(viewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date, Customers")] Order order)
        {
            if (ModelState.IsValid)
            {
                var customer=_custManager.Create(order.Customers);
                order.CustomersId = customer.Id;


                //Empties the cart and add movis to order
                var cart = Session["cart"] as ShoppingCart;
                if (cart == null) cart = new ShoppingCart();
                order.Movies = cart.Movies;
                cart.Movies = new List<Movie>();
                Session["cart"] = cart;

                _manager.Create(order);
                return RedirectToAction("Index");
            }
            var viewModel = new OrderBasketViewModel
            {
                Order = order,
            };
            return View(viewModel);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _manager.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _manager.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _manager.Delete(_manager.Read(id));
            return RedirectToAction("Index");
        }
    }
}
