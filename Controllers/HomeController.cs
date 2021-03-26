using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 2.3.21

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;


        //private IFilmsRepository _repository;
        private FilmListContext context { get; set; }

        //public HomeController(ILogger<HomeController> logger, IFilmsRepository repository, FilmListContext con)
        //{
        //    _logger = logger;
        //    _repository = repository;
        //    context = con;
        //}


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

        [HttpPost]
        public IActionResult FilmForm(FormResponse formResponse)
        {
            //TempStorage.AddMovie(formResponse); //Adds form info to tempstorage
            //return View("FilmForm", formResponse);
            if (ModelState.IsValid)
            {
                //Update database
                context.FormResponses.Add(formResponse);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View(context.FormResponses);
        }

        [HttpPost]
        public IActionResult MovieList(int FilmId)
        {
            var movie = context.FormResponses.FirstOrDefault(m => m.FilmId == FilmId);
            context.FormResponses.Remove(movie);
            context.SaveChanges();
            return View(context.FormResponses);
        }

        [HttpPost]
        public IActionResult EditFilm(int FilmId)
        {
            var movie = context.FormResponses.FirstOrDefault(m => m.FilmId == FilmId);
            return View("Update", movie);
        }


        [HttpPost]
        public IActionResult FilmUpdateForm(FormResponse formResponse)
        {
            //var movie = context.FormResponses.FirstOrDefault(m => m.FilmId == FilmEditId);
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
