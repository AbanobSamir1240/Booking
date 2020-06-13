using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GpBooking.Models;
using GpBooking.Services;

namespace GpBooking.Controllers.Booking
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HotelController()
        {
            _db = new ApplicationDbContext();
        }

        [AllowAnonymous]
        // GET: Hotel/Details/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Hotel hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(hotel);
        }

        [HttpGet]
        [Authorize(Roles = RoleName.All)]
        public ActionResult Booking(int? Room)
        {
            if (Room == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var hotelRoom = _db.HotelRooms.FirstOrDefault(l => l.Id == Room);
            if (hotelRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(hotelRoom);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(HotelReservations reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.Id == 0)
                {

                    _db.HotelReservations.Add(new HotelReservations()
                    {
                        ApplicationUserId = ApplicationUserService.GetUserId(),
                        EndDate = reservation.EndDate,
                        HotelRoomsId = reservation.HotelRoomsId,
                        PaymentType = reservation.PaymentType,
                        StartDate = reservation.StartDate,
                        ReservationDate = DateTime.Now
                    });
                    _db.SaveChanges();
                    var body =
                        $"{MailService.HandleOne(FileService.ReadFile(Server.MapPath("~/Files/Emails/1.txt")), new HotelReservations() {EndDate = reservation.EndDate, PaymentType = reservation.PaymentType, StartDate = reservation.StartDate, ReservationDate = DateTime.Now, ApplicationUser = ApplicationUserService.GetUser(), HotelRooms = _db.HotelRooms.FirstOrDefault(l => l.Id == reservation.HotelRoomsId),})}";
                    MailService.SendMail(Services.ApplicationUserService.GetUser().Email,
                        "Booking Confirmation", body);
                    return View("BookingConfirm");
                }
                else
                {
                    var currentUser = ApplicationUserService.GetUserId();
                    var hotelRes = _db.HotelReservations.FirstOrDefault(l =>
                        l.Id == reservation.Id && l.ApplicationUserId == currentUser);
                    if (hotelRes != null)
                    {

                        hotelRes.EndDate = reservation.EndDate;
                        hotelRes.HotelRoomsId = reservation.HotelRoomsId;
                        hotelRes.PaymentType = reservation.PaymentType;
                        hotelRes.StartDate = reservation.StartDate;
                        _db.Entry(hotelRes).State = EntityState.Modified;
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Profile", "Manage");
                }
            }

            return RedirectToAction("Booking", new {Room = reservation.HotelRoomsId});
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
        public ActionResult BookingRoom(int Room)
        {
            return PartialView("_BookingRoom", new HotelReservations()
            {
                HotelRooms = _db.HotelRooms.FirstOrDefault(l => l.Id == Room),
                Id = 0,
                StartDate = DateTime.Today,
                ApplicationUserId = Services.ApplicationUserService.GetUserId(),
                HotelRoomsId = Room,
                PaymentType = PaymentType.Cash,
                ReservationDate = DateTime.Today
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
            var hotelRoom = _db.HotelReservations.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (hotelRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(hotelRoom);
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult Checkin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var currentUser = ApplicationUserService.GetUserId();
            var hotelRoom = _db.HotelReservations.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (hotelRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(hotelRoom);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Checkin(int CheckId)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var hotelRes = _db.HotelReservations.FirstOrDefault(l =>
                l.Id == CheckId && l.ApplicationUserId == currentUser);
            if (hotelRes != null)
            {

                hotelRes.IsCheckIn = !hotelRes.IsCheckIn;
                _db.Entry(hotelRes).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult DeleteBooking(int id)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var hotelRes = _db.HotelReservations.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (hotelRes != null)
            {
                _db.Entry(hotelRes).State = EntityState.Deleted;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }
    }
}
