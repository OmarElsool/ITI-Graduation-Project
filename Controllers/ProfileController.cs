using Airbnb.Data;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Airbnb.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProfileController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpPost]
        public IActionResult ProfileInfo(ProfileInfoViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
            }
            currentUser.City = model.Location;
            currentUser.Work = model.Work;
            currentUser.Language = model.Language;
            currentUser.Description = model.Description;
            db.SaveChanges();
            return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
        }
    }
}
