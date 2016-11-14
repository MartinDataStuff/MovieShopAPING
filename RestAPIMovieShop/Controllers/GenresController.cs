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
    public class GenresController : ApiController
    {
        private IRepository<Genre> db = new MovieShopDLLFacade().GetGenreRepository();

        // GET: api/Genres
        public List<Genre> GetGenres()
        {
            return db.ReadAll();
        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = db.Read(id);

            return Ok(genre);
        }

        // PUT: api/Genres/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest();
            }

            try
            {
                db.Update(genre);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        [Authorize]
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(genre);

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [Authorize]
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = db.Read(id);
            db.Delete(genre);
            return Ok(genre);
        }

        private bool GenreExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}