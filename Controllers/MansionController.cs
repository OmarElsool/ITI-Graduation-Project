using Airbnb.Data;
using Airbnb.Models;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Identity;
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
            var mansionState = db.Mansions.Include(m => m.Reviews).Include(m => m.Reservations).ThenInclude(m => m.User).Where(m => m.UserId == userId).ToList();
            return View(mansionState);
        }
        public IActionResult MansionOffer(byte state, int reservationId)
        {
            var mansionReservation = db.Reservations.Find(reservationId);
            if (mansionReservation == null)
            {
                return NotFound();
            }
            if (state == 1)
            {
                mansionReservation.Approved = true;
            }
            else
            {
                mansionReservation.Approved = false;
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "SomeThing Wrong With Review");
                return RedirectToAction("mansionDetails", "Home", new { id = model.MansionId });
            }
            var review = db.Reviews.FirstOrDefault(r => r.UserId == model.UserId && r.MansionId == model.MansionId);
            if (review != null)
            {
                ModelState.AddModelError("", "You Already Have Reviewed");
                return RedirectToAction("mansionDetails", "Home", new { id = model.MansionId });
            }
            review = new Review
            {
                UserId = model.UserId,
                MansionId = model.MansionId,
                Comment = model.ReviewComment,
                Rating = model.ReviewRating,
                CreatedAt = DateTime.Now,
            };
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("mansionDetails", "Home", new { id = model.MansionId });

        }
        public IActionResult Reservation(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ReservationErr", "Something Went Wrong");
                return RedirectToAction("mansionDetails", "Home", new { id = model.MansionId });
            }
            var mansion = db.Mansions.FirstOrDefault(m => m.Id == model.MansionId);
            var mansionPhoto = db.MansionsPhotos.Where(m => m.MansionId == model.MansionId).FirstOrDefault();
            ViewBag.mansionReservation = mansion;
            ViewBag.mansionPhoto = mansionPhoto;
            return View(model);
        }
        [HttpPost]
        public IActionResult Transaction(ReservationViewModel Reservation)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("customErr", "something went wrong");
                //return View(Reservation);
                return RedirectToAction("Reservation", new
                {
                    MansionId = Reservation.MansionId,
                    UserId = Reservation.UserId,
                    CheckIn = Reservation.CheckIn,
                    CheckOut = Reservation.CheckOut,
                    Price = Reservation.Price,
                    GuestNo = Reservation.GuestNo,
                });
            }
            //var reservation = db.Reservations.FirstOrDefault(r => r.MansionId == Reservation.MansionId);
            //if (reservation != null)
            //{
            //    ModelState.AddModelError("customErr", "you already reserve this mansion");
            //    return RedirectToAction("Reservation", new
            //    {
            //        MansionId = Reservation.MansionId,
            //        UserId = Reservation.UserId,
            //        CheckIn = Reservation.CheckIn,
            //        CheckOut = Reservation.CheckOut,
            //        Price = Reservation.Price,
            //        GuestNo = Reservation.GuestNo,
            //    });
            //}
            var reservation = new Reservation
            {
                MansionId = Reservation.MansionId,
                Check_in = Reservation.CheckIn,
                Check_out = Reservation.CheckOut,
                NoGuests = Reservation.GuestNo,
                UserId = Reservation.UserId,
                PostDate = DateTime.Now,
            };
            db.Reservations.Add(reservation);
            db.SaveChanges();
            var trans = new Transactions
            {
                Amount = Reservation.Price,
                Date = DateTime.Now,
                ReservationId = reservation.Id
            };
            db.Transactions.Add(trans);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
