using MovieMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMVC.Daten
{
    public class Data
    {
        private static List<Movie> Movies = new List<Movie>();

        public Movie getById(int id)
        {
            for (int i = 0; i < Movies.Count; i++)
            {
                if (id == Movies[i].Id)
                {
                    return Movies[i];
                }
            }
            return null;
        }

        public List<Movie> getAll()
        {
            return Movies;
        }


        public void delete(int id)
        {
            var Movie = getById(id);
            if (Movie != null)
            {
                Movies.Remove(Movie);
            }
        }

        public static void print(string msg)
        {
            Console.WriteLine(msg);
        }


        public void update(Movie Movie)
        {
            var oldMovie = getById(Movie.Id);
            if (oldMovie != null)
            {
                oldMovie.Name = Movie.Name;
                oldMovie.Preis = Movie.Preis;
                oldMovie.Beschreibung = Movie.Beschreibung;
                oldMovie.Datum = Movie.Datum;
            }

        }

        public void create(Movie neuermovie)
        {

            int grössteId = 0;
            foreach (Movie movie in Movies)
            {
                if (grössteId < movie.Id)
                {
                    grössteId = movie.Id;
                }
            }

            int id = grössteId + 1;
            neuermovie.Id = id;
            Movies.Add(neuermovie);
        }

        public static void umdrehen()
        {
            Movie[] MovieArray = new Movie[Movies.Count];
            int counter = Movies.Count - 1;

            for (int i = 0; i < Movies.Count; i++)
            {
                MovieArray[counter] = Movies[i];
                counter--;
            }

            for (int i = 0; i < Movies.Count; i++)
            {
                Movies[i] = MovieArray[i];
            }



        }


        static Data()
        {
            Movies.Add(new Movie { Id = 1, Name = "Starwars", Beschreibung = "Ist gut", Preis = 9.99 });
            Movies.Add(new Movie {Id=2, Name = "Ice Age", Beschreibung = "Ist behiundert gut", Preis = 15.99 });
            Movies.Add(new Movie {Id=3, Name = "Mr.Bean", Beschreibung = "Ist ok", Preis = 5.99 });
        }









    }
}
