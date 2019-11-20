using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jWebapp.Models
{
    public class Actor
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public int born { get; set; }

        public Actor(string name)
        {
            var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "root"));
            var session = driver.Session();

            string statement = "MATCH(p:Person{name:'" + name + "'}) return p";

            IStatementResult result = session.Run(statement);

            INode node = null;
            string nameOut;
            string lastnameOut;
            int bornOut;

            foreach (var record in result)
            {
                node = record["p"].As<INode>();
                nameOut = node["name"].As<string>();
                lastnameOut = node["lastname"].As<string>();
                bornOut = node["born"].As<int>();

                this.name = nameOut;
                this.lastname = lastnameOut;
                this.born = bornOut;
            }
            
        }

        public List<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>();

            var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "root"));
            var session = driver.Session();

            string statement = "MATCH(p:Person{name:'" + this.name + "'})-[:ACTED_IN]->(m:Movie) return m";

            IStatementResult result = session.Run(statement);

            INode node = null;
            string movieTitle;
            string movieTagline;
            int movieReleased;

            foreach (var record in result)
            {
                node = record["m"].As<INode>();
                movieTitle = node["title"].As<string>();
                movieTagline = node["tagline"].As<string>();
                movieReleased = node["released"].As<int>();

                Movie movie = new Movie();
                movie.title = movieTitle;
                movie.tagline = movieTagline;
                movie.released = movieReleased;

                movies.Add(movie);
            }

            return movies;
        }
    }
}
