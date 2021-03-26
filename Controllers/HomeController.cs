using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3.25.21

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private FilmListContext context { get; set; }

        //constructor
        public HomeController(FilmListContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmForm()
        {
            return View(); //Default here is to take to the view in home that has the same name
        }

        [HttpPost] //adds a record to the database
        public IActionResult FilmForm(FormResponse formResponse)
        {
            if (ModelState.IsValid)
            {
                //Update database
                context.FormResponses.Add(formResponse);
                context.SaveChanges();
            }

            return View("Submitted");
        }

        [HttpGet] //returns the list of movies in the database
        public IActionResult MovieList()
        {
            return View(context.FormResponses);
        }

        [HttpPost]
        public IActionResult MovieList(int FilmId) //matches the filmId with the one in the database and deletes record
        {
            var movie = context.FormResponses.FirstOrDefault(m => m.FilmId == FilmId);
            context.FormResponses.Remove(movie);
            context.SaveChanges();
            return View(context.FormResponses);
        }

        [HttpPost] //passes the move information into the update view
        public IActionResult EditFilm(int FilmId)
        {
            var movie = context.FormResponses.FirstOrDefault(m => m.FilmId == FilmId);
            return View("Update", movie);
        }


        [HttpPost] //updates the form response and displays the updated movie list
        public IActionResult FilmUpdateForm(FormResponse formResponse)
        {
            if (ModelState.IsValid)
            {
                //Update database
                context.FormResponses.Update(formResponse);
                context.SaveChanges();
            }
            return View("MovieList", context.FormResponses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
