using Airbnb.Data;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Airbnb.Controllers
{
    [Authorize]
    public class ManageListing : Controller
    {
        ApplicationDbContext db;

        public ManageListing(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var mansionSlider = new MansionSliderViewModel
            {
                Mansion = new Mansion(),
                MansionCategories = db.MansionsCategories.ToList(),
                ServiceTypes = db.ServicesType.Include(s => s.Service).ToList()
            };
            return View("GenerateMansion", mansionSlider);
        }
        [HttpPost]
        public IActionResult GenerateMansion(CreateMansionViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "SomeThing Went Wrong");
                var mansionSlider = new MansionSliderViewModel
                {
                    Mansion = new Mansion(),
                    MansionCategories = db.MansionsCategories.ToList(),
                    ServiceTypes = db.ServicesType.Include(s => s.Service).ToList()
                };
                return View("GenerateMansion", mansionSlider);
            }
            List<ServiceModel> services = new List<ServiceModel>();
            foreach (var service in model.mansionService)
            {
                var srvc = db.Services.First(s => s.Id == service);
                services.Add(srvc);
            }
            Mansion mansion = new Mansion
            {
                City = model.City,
                Street = model.Street,
                Zipcode = model.Zipcode,
                Build_No = model.Build_No,
                Title = model.Title,
                Description = model.Description,
                NoBed = model.NoBed,
                NoBathroom = model.NoBathroom,
                NoBedroom = model.NoBedroom,
                NoGuest = model.NoGuest,
                Price = model.Price,
                UserId = userId,
                PostDate = DateTime.Now,
                Services = services,
                Category = db.MansionsCategories.First(c => c.Id == model.placeType),
            };
            db.Mansions.Add(mansion);
            db.SaveChanges();
            foreach (var photo in model.photos)
            {
                string photoName = UploadFiles(photo);
                var mansionPhoto = new MansionPhotoModel
                {
                    MansionId = mansion.Id,
                    MansionPhoto = photoName,
                };
                db.MansionsPhotos.Add(mansionPhoto);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public string UploadFiles(IFormFile file)
        {
            string fileName = "";
            if (file != null)
            {
                var extention = file.FileName.Split(".").Last();

                fileName = Guid.NewGuid().ToString() + "_" + file.Name + "." + extention;


                using (var fileStream = System.IO.File.Create("wwwroot/Images/mansionsPhotos/" + fileName))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
