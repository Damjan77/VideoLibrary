using AV_MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AV_MVC1.Controllers
{
    public class MoviesController : Controller
    {

        static List<Movie> moviesList = new List<Movie>()
        {
            new Movie() { name = "Mechanic 2!", rating = 4.8f, downloadURL =@"https://archive.org/details/Shrek.The.Halls.720p", imageURL=@"data:image/jpeg;base64,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"}
        };
        static List<Client> clients = new List<Client>() {
            new Client() {name = "Damjan", address="8mi Sept", phone="078214507", MovieCard="movieCard", age=22}
        };
        

        public ActionResult GetAllMovies()
        {
            return View(moviesList);
        }

        public ActionResult GetAllClients()
        {
            return View(clients);
        }

        public ActionResult ShowMovie(int id)
        {
            var movie = moviesList.ElementAt(id);
            MovieRentals model = new MovieRentals();
            model.movie = movie;
            model.clients = clients;
            return View(model);
        }

        public ActionResult NewClient()
        {
            Client model = new Client();
            return View(model);
        }

        public ActionResult NewMovie()
        {
            Movie model = new Movie();
            return View(model);
        }

        [HttpPost]
        public ActionResult InsertNewClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient", model);
            }

            clients.Add(model);
            return View("GetAllClients", clients);
        }


        [HttpPost]
        public ActionResult InsertNewMovie(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewMovie", model); // Go prenasocuvame kon NewMovie i go prakjame istiot model
            }
            moviesList.Add(model);
            return View("GetAllMovies", moviesList);
        }


        public ActionResult ShowClient(int id)
        {
            Client model = clients.ElementAt(id);
            return View(model);
        }

        public ActionResult EditMovie(int id)
        {
            var model = moviesList.ElementAt(id);
            model.id = id;
            return View(model);
        }

        public ActionResult EditClient(int id)
        {
            var model = clients.ElementAt(id);
            model.id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovie(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditMovie",model);
            }

            var forUpdate = moviesList.ElementAt(model.id);
            forUpdate.imageURL = model.imageURL;
            forUpdate.name = model.name;
            forUpdate.downloadURL = model.downloadURL;
            forUpdate.rating = model.rating;
            return View("GetAllMovies", moviesList);
        }



        [HttpPost]
        public ActionResult EditClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditClient", model);
            }

            var forUpdate = clients.ElementAt(model.id);
            
            forUpdate.name = model.name;
            forUpdate.address = model.address;
            forUpdate.age = model.age;
            forUpdate.phone = model.phone;
            return View("GetAllClients", clients);
        }


        public ActionResult DeleteMovie(int id)
        {
            moviesList.RemoveAt(id);
            return View("GetAllMovies",moviesList);
        }

        public ActionResult DeleteClient(int id)
        {
            clients.RemoveAt(id);
            return View("GetAllClients", clients);
        }
    }
}
