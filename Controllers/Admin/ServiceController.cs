using Airbnb.Data;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Controllers.Admin
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext db;

        public ServiceController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var servicesTypes = db.ServicesType.Include(s => s.Service).ToList();
            return View(servicesTypes);
        }
        public IActionResult AddServiceType(ServiceTypeModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("serviceType", "Not Valid Type");
                var servicesTypes = db.ServicesType.Include(s => s.Service).ToList();
                return View(nameof(Index), servicesTypes);
            }
            db.ServicesType.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddService()
        {
            ViewData["Id"] = new SelectList(db.ServicesType, "Id", "ServiceType");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddService(ServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("All", "SomeThing Went Wrong");
                ViewData["Id"] = new SelectList(db.ServicesType, "Id", "ServiceType");
                return View(model);
            }
            db.Services.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteService(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Service = db.Services.Find(id);
            if (Service == null)
            {
                return NotFound();
            }
            db.Services.Remove(Service);
            db.SaveChanges();
            return Ok();
        }
        public IActionResult DeleteServiceType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ServiceType = db.ServicesType.Find(id);
            if (ServiceType == null)
            {
                return NotFound();
            }
            foreach (var service in ServiceType.Service)
            {
                db.Services.Remove(service);
            }
            db.ServicesType.Remove(ServiceType);
            db.SaveChanges();
            return Ok();
        }
        public IActionResult EditServiceType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ServiceType = db.ServicesType.Find(id);
            if (ServiceType == null)
            {
                return NotFound();
            }
            return View(ServiceType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditServiceType(ServiceTypeModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ServiceType", "something Went Wrong");
                return View(nameof(EditServiceType));
            }
            var serviceType = db.ServicesType.Find(model.Id);
            if (serviceType == null)
            {
                return NotFound();
            }
            serviceType.ServiceType = model.ServiceType;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
