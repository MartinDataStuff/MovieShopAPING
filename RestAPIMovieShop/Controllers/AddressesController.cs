using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Contexts;
using MovieShopDLL.Entity;

namespace RestAPIMovieShop.Controllers
{
    public class AddressesController : ApiController
    {
        private IRepository<Addresses> db = new MovieShopDLLFacade().GetAddressRepository();

        // GET: api/Addresses
        public List<Addresses> GetAddresses()
        {
            return db.ReadAll();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult GetAddresses(int id)
        {
            Addresses addresses = db.Read(id);
            if (addresses == null)
            {
                return NotFound();
            }

            return Ok(addresses);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddresses(int id, Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addresses.Id)
            {
                return BadRequest();
            }

            try
            {
                db.Update(addresses);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult PostAddresses(Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(addresses);

            return CreatedAtRoute("DefaultApi", new { id = addresses.Id }, addresses);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult DeleteAddresses(int id)
        {
            Addresses addresses = db.Read(id);

            db.Delete(addresses);

            return Ok(addresses);
        }

        private bool AddressesExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}