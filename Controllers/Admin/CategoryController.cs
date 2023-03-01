using Airbnb.Data;
using Airbnb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var categories = db.MansionsCategories.ToList();
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(MansionCategory category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "Name Is Required");
                var categories = db.MansionsCategories.ToList();
                return View(categories);
            }
            db.MansionsCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = db.MansionsCategories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            db.MansionsCategories.Remove(category);
            db.SaveChanges();
            return Ok();
        }
    }
}
