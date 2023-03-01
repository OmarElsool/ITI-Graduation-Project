using Airbnb.Data;
using Airbnb.Dtos;
using Airbnb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        readonly ApplicationDbContext db;
        //private readonly UserManager<AppUser> userManger;
        //private readonly SignInManager<AppUser> signInManger;

        public AdminController(ApplicationDbContext _db)
        {
            db = _db;
        }
        // Dashboard Page
        public IActionResult Index()
        {
            var mansions = db.Mansions.Include(m => m.User).Include(m => m.Category).OrderByDescending(m => m.PostDate).Take(10).ToList();
            return View(mansions);
        }
        [HttpGet]
        public JsonResult SearchMansionByName(string mansion)
        {
            var mansions = db.Mansions.Where(m => m.Title.Contains(mansion)).Take(10).Select(m =>
                new MansionUserDto()
                {
                    MansionId = m.Id,
                    ClientName = m.User.Email,
                    MansionCategory = m.Category.Name,
                    MansionTitle = m.Title,
                    PostDate = m.PostDate,
                    Price = m.Price
                }).ToList();

            return Json(mansions);
        }
        public IActionResult MansionState(int mansionId, string mansionState)
        {
            var mansion = db.Mansions.Find(mansionId);
            if (mansion == null)
            {
                return NotFound();
            }
            if (mansionState == "1")
            {
                mansion.Approved = true;
            }
            else
            {
                mansion.Approved = false;
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult MansionDetails(int mansionId)
        {
            var mansion = db.Mansions.Include(m => m.User).Include(m => m.Category).FirstOrDefault(m => m.Id == mansionId);
            if (mansion == null)
            {
                return NotFound();
            }
            return View(mansion);
        }
        public IActionResult MansionDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mansion = db.Mansions.FirstOrDefault(m => m.Id == id);
            if (mansion == null)
            {
                return NotFound();
            }
            db.Mansions.Remove(mansion);
            db.SaveChanges();
            return Ok();
        }
    }
}
