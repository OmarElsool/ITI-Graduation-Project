using Airbnb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Airbnb.Controllers
{
    public class MansionController : Controller
    {
        private readonly ApplicationDbContext db;

        public MansionController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var mansionState = db.Mansions.Include(m => m.Reservations).ThenInclude(m => m.User).Where(m => m.UserId == userId).ToList();
            return View(mansionState);
        }
    }
}
