using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GpBooking.Models;
using GpBooking.Services;

namespace GpBooking.Controllers.Booking
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RestaurantController()
        {
            _db = new ApplicationDbContext();
        }


        [HttpGet]
        [Authorize(Roles = RoleName.All)]
        public ActionResult Booking(int? Table)
        {
            if (Run.Decrypt(ApplicationService.ReadFromWebConfig("runtime"), Run.GenerateEncryptionKey()) == "close" ||
                ApplicationService.ReadFromWebConfig("runtime") == "" ||
                ApplicationService.ReadFromWebConfig("runtime") == null)
            {
                return RedirectToAction("Main", "Account");
            }
            if (Table == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var restaurantTable = _db.Restaurants.FirstOrDefault(l => l.Id == Table);
            if (restaurantTable == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(restaurantTable);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(RestaurantReservations reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.Id == 0)
                {

                    _db.RestaurantReservationses.Add(new RestaurantReservations()
                    {
                        ApplicationUserId = ApplicationUserService.GetUserId(),
                        PaymentType = reservation.PaymentType,
                        Date = reservation.Date,
                        ReservationDate = DateTime.Now,
                        NumberOfTable = reservation.NumberOfTable,
                        RestaurantId = reservation.RestaurantId
                    });
                    _db.SaveChanges();
                    var body =
                        $"{MailService.HandleThree(FileService.ReadFile(Server.MapPath("~/Files/Emails/3.txt")), new RestaurantReservations() {NumberOfTable = reservation.NumberOfTable, PaymentType = reservation.PaymentType, Date = reservation.Date, ReservationDate = DateTime.Now, ApplicationUser = ApplicationUserService.GetUser(), Restaurant = _db.Restaurants.FirstOrDefault(l => l.Id == reservation.RestaurantId),})}";
                    MailService.SendMail(Services.ApplicationUserService.GetUser().Email,
                        "Booking Confirmation", body);
                    return View("BookingConfirm");
                }
                else
                {
                    var currentUser = ApplicationUserService.GetUserId();
                    var restaurantRes = _db.RestaurantReservationses.FirstOrDefault(l =>
                        l.Id == reservation.Id && l.ApplicationUserId == currentUser);
                    if (restaurantRes != null)
                    {

                        restaurantRes.NumberOfTable = reservation.NumberOfTable;
                        restaurantRes.RestaurantId = reservation.RestaurantId;
                        restaurantRes.PaymentType = reservation.PaymentType;
                        restaurantRes.Date = reservation.Date;
                        _db.Entry(restaurantRes).State = EntityState.Modified;
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Profile", "Manage");
                }
            }

            return RedirectToAction("Booking", new {Table = reservation.RestaurantId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult BookingTable(int Table)
        {
            return PartialView("_BookingTable", new RestaurantReservations()
            {
                Id = 0,
                Date = DateTime.Today,
                ApplicationUserId = ApplicationUserService.GetUserId(),
                PaymentType = PaymentType.Cash,
                ReservationDate = DateTime.Today,
                NumberOfTable = 1,
                RestaurantId = Table,
            });
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult EditBooking(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var currentUser = ApplicationUserService.GetUserId();
            var restaurantTable = _db.RestaurantReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (restaurantTable == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(restaurantTable);
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult Checkin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var currentUser = ApplicationUserService.GetUserId();
            var restaurantTable = _db.RestaurantReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (restaurantTable == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(restaurantTable);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Checkin(int CheckId)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var restaurantRes = _db.RestaurantReservationses.FirstOrDefault(l =>
                l.Id == CheckId && l.ApplicationUserId == currentUser);
            if (restaurantRes != null)
            {

                restaurantRes.IsCheckIn = !restaurantRes.IsCheckIn;
                _db.Entry(restaurantRes).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult DeleteBooking(int id)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var restaurantRes = _db.RestaurantReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (restaurantRes != null)
            {
                _db.Entry(restaurantRes).State = EntityState.Deleted;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }

        public ActionResult GetRestaurant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }
    }
}