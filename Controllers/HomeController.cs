using Airbnb.Data;
using Airbnb.Dtos;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Airbnb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            HomeControlerViewModel homeControlerViewModel = new HomeControlerViewModel();
            homeControlerViewModel.Mansion = db.Mansions.Include(a => a.MansionPhotos).ToList();
            homeControlerViewModel.MansionCategories = db.MansionsCategories.ToList();
            return View(homeControlerViewModel);
        }

        public IActionResult FilterMansion(int CategoryId)
        {
            HomeControlerViewModel homeControlerViewModel = new HomeControlerViewModel();
            homeControlerViewModel.Mansion = (from m in db.Mansions
                                              where m.CategoryId == CategoryId
                                              select m).Include(a => a.MansionPhotos).ToList();
            homeControlerViewModel.MansionCategories = db.MansionsCategories.ToList();
            ViewBag.id = CategoryId;
            return View(homeControlerViewModel);
        }
        public IActionResult mansionDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mansion = db.Mansions.Include(m => m.Services).Include(m => m.Reviews).Include(m => m.MansionPhotos).Include(m => m.User).FirstOrDefault(m => m.Id == id);
            return View(mansion);
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
        public IActionResult ShowAll()
        {
            return View();
        }
    }
}