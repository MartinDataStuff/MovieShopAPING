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

namespace WebAdmin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IManager<Customer> _manager = new MovieShopDLLFacade().GetCustomerManager();


        // GET: Customers
        public ActionResult Index()
        {
            return View(_manager.ReadAll());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _manager.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.AddressesId = new SelectList(new MovieShopDLLFacade().GetAddressManager().ReadAll(), "Id", "DisplayName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNr,AddressesId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(customer);
                return RedirectToAction("Index");
            }
            ViewBag.AddressesId = new SelectList(new MovieShopDLLFacade().GetAddressManager().ReadAll(), "Id", "DisplayName");
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _manager.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressesId = new SelectList(new MovieShopDLLFacade().GetAddressManager().ReadAll(), "Id", "DisplayName");
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNr,AddressesId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(customer);
                return RedirectToAction("Index");
            }
            ViewBag.AddressesId = new SelectList(new MovieShopDLLFacade().GetAddressManager().ReadAll(), "Id", "DisplayName");
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _manager.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _manager.Delete(_manager.Read(id));
            return RedirectToAction("Index");
        }

    }
}
