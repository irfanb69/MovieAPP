using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Daten;
using MovieMVC.Models;

namespace MovieMVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index(string filter)
        { 
            Data data = new Data();

            var movies = data.getAll();

            if(!String.IsNullOrEmpty(filter))
            {
                List<Movie> filterMovie = new List<Movie>();



                foreach(Movie movie in movies)
                {
                    if (movie.Name.Contains(filter))
                    {
                        filterMovie.Add(movie);
                    }
                }

                movies = filterMovie; 



            }

            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie m)
        {
            Data data = new Data();

            data.create(m);


            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Data data = new Data();

            var movie = data.getById(id);

            return View(movie);
            

        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            Data data = new Data();

            data.update(movie);


            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Data data = new Data();

            var movie = data.getById(id);

            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Data data = new Data();
            data.delete(id);

            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            Data data = new Data();

            var movie = data.getById(id);

            return View(movie);



        }



    }
}
