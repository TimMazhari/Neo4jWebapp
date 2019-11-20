using Microsoft.AspNetCore.Mvc;
using Neo4jWebapp.Models;
using Neo4jWebapp.ViewModels;
using System.Collections.Generic;

namespace Neo4jWebapp.Controllers
{
    public class MoviesOfActorController : Controller
    {
        public IActionResult MoviesOfActor()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult getMovies(string actorName)
        {
            Actor actor = new Actor(actorName);

            List<Movie> movies = new List<Movie>();
            movies = actor.getMovies();

            ActorMoviesViewModel actorMoviesViewModel = new ActorMoviesViewModel();
            actorMoviesViewModel.actor = actor;
            actorMoviesViewModel.movies = movies;


            return View(actorMoviesViewModel);
        }
    }
}