using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jWebapp.Models
{
    public class Movie
    {
        public string title { get; set; }
        public string tagline { get; set; }
        public int released { get; set; }
    }
}
