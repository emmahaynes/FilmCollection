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
        private readonly ILogger<HomeController> _logger;


        private IFilmsRepository _repository;
        private FilmListContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, IFilmsRepository repository, FilmListContext con)
        {
            _logger = logger;
            _repository = repository;
            context = con;
        }


        ////constructor
        //public HomeController(FilmListContext con)
        //{
        //    context = con;
        //}

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

        public IActionResult MovieList()
        {
            //return View(TempStorage.Forms.Where(r => r.Title != "Independence Day")); 
            //excludes Independence Day from displaying
            return View(context.FormResponses);
        }

        //public IActionResult Update(string filmname)
        //{
        //    FormResponse film = Repository.AllEmpoyees.Where(e => e.Name == filmname).FirstOrDefault();
        //    return View(film);
        //}

        //[HttpPost]
        //public IActionResult Update(FormResponse film, string filmname)
        //{
        //    Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Age = employee.Age;
        //    Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Salary = employee.Salary;
        //    Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
        //    Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
        //    Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;

        //    return RedirectToAction("Index");
        //}

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
