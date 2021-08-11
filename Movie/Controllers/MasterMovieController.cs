using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
using Movie.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class MasterMovieController : Controller
    {
        private readonly MovieContext _movieContext;
        private readonly MasterMovieService _masterMovieService;
        public MasterMovieController(MovieContext movieContext)
        {
            //Dependency
            _movieContext = movieContext;
            _masterMovieService = new MasterMovieService(_movieContext);

        }
        // GET: MasterMovieController
        public ActionResult Index()
        {
            var movies = _masterMovieService.GetAll();
            return View(movies);
        }

        // GET: MasterMovieController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: MasterMovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.AddMovie(item);
            return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterMovieController/Edit/5
        public ActionResult Edit(int id)
        {
            MasterMovie item = _masterMovieService.GetEditMovie(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.PostEditMovie(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterMovieController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MasterMovieController/Delete/5

        public ActionResult Delete(int id)
        {
            _masterMovieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
