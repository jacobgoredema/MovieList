using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext dbContext { get; set; }

        public MovieController(MovieContext context)
        {
            dbContext = context;

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = dbContext.Genres.OrderBy(g => g.Name).ToList();

            return View("Edit", new Movie());

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = dbContext.Genres.OrderBy(g => g.Name).ToList();
            var movie = dbContext.Movies.Find(id);

            return View(movie);

        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                    dbContext.Movies.Add(movie);
                else
                    dbContext.Movies.Update(movie);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                ViewBag.Genres = dbContext.Genres.OrderBy(g => g.Name).ToList();

                return View(movie);

            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = dbContext.Movies.Find(id);

            return View(movie);

        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

    }
}