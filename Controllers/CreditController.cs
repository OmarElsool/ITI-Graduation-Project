using Airbnb.Data;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Airbnb.Controllers
{
    public class CreditController : Controller
    {
        private readonly ApplicationDbContext db;

        public CreditController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Create(CreditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "SomeThing Went Wrong");
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });

            }
            var CreditExist = db.CreditCards.FirstOrDefault(c => c.UserId == model.UserId);
            if (CreditExist != null)
            {
                ModelState.AddModelError("", "Credit Already Exist");
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });

            }
            var newCredit = new CreditCard
            {
                CardNumber = model.CardNumber,
                Expiration = model.Expiration,
                CVV = model.CVV,
                UserId = model.UserId
            };
            db.CreditCards.Add(newCredit);
            db.SaveChanges();
            return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });

        }
    }
}
