using Microsoft.AspNetCore.Mvc;
using Neo4jWebapp.Models;
using Neo4jWebapp.ViewModels;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Neo4jWebapp.Controllers
{
    public class MoviesOfActorController : Controller
    {
        private static ActorMoviesViewModel actorMoviesViewModel = null;

        public IActionResult MoviesOfActor(bool initial)
        {
            if (initial)
            {
                return View();
            }
            else
            {
                return View(actorMoviesViewModel);
            }
        }

        [HttpPost]
        public ActionResult getMovies(string actorName)
        {
            Actor actor = new Actor(actorName);

            List<Movie> movies = new List<Movie>();
            movies = actor.getMovies();
            actorMoviesViewModel = new ActorMoviesViewModel();
            actorMoviesViewModel.actor = actor;
            actorMoviesViewModel.movies = movies;

            return RedirectToAction("MoviesOfActor", "MoviesOfActor", false);
        }
    }
}