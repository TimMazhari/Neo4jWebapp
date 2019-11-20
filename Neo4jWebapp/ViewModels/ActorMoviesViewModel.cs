using Neo4jWebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Neo4jWebapp.ViewModels
{
    public class ActorMoviesViewModel
    {
        public Actor actor { get; set; }
        public List<Movie> movies { get; set; }
    }
}
