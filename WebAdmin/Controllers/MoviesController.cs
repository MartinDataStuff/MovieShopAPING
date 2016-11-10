using System.Net;
using System.Web.Mvc;
using MovieShopBE;
using MovieShopDLL;

namespace WebAdmin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IManager<Movie> _manager = new MovieShopDLLFacade().GetMovieManager();

        // GET: Movies
        public ActionResult Index()
        {
            return View(_manager.ReadAll());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _manager.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenresId = new SelectList(new MovieShopDLLFacade().GetGenreManager().ReadAll(), "Id","Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,GenresId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie = _manager.Create(movie);
                return RedirectToAction("Index");
            }
            ViewBag.GenresId = new SelectList(new MovieShopDLLFacade().GetGenreManager().ReadAll(), "Id","Name");
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _manager.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenresId = new SelectList(new MovieShopDLLFacade().GetGenreManager().ReadAll(), "Id", "Name");
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,GenresId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(movie);
                return RedirectToAction("Index");
            }

            ViewBag.GenresId = new SelectList(new MovieShopDLLFacade().GetGenreManager().ReadAll(), "Id", "Name");
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _manager.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _manager.Delete(_manager.Read(id));
            return RedirectToAction("Index");
        }
    }
}
