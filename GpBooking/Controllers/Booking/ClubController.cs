using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GpBooking.Models;
using GpBooking.Services;

namespace GpBooking.Controllers.Booking
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClubController()
        {
            _db = new ApplicationDbContext();
        }

        [AllowAnonymous]
        // GET: Club/Details/5
        public ActionResult Get(int? id)
        {
            if (Run.Decrypt(ApplicationService.ReadFromWebConfig("runtime"), Run.GenerateEncryptionKey()) == "close" ||
                ApplicationService.ReadFromWebConfig("runtime") == "" ||
                ApplicationService.ReadFromWebConfig("runtime") == null)
            {
                return RedirectToAction("Main", "Account");
            }
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Club club = _db.Clubs.Find(id);
            if (club == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Checkin =
                _db.ClubReservationses.Count(l => l.StartDate <= DateTime.Today && l.EndDate >= DateTime.Today) == 0;
            return View(club);
        }

        [HttpGet]
        [Authorize(Roles = RoleName.All)]
        public ActionResult Booking(int? club)
        {
            if (club == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var clubRoom = _db.Clubs.FirstOrDefault(l => l.Id == club);
            if (clubRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(clubRoom);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(ClubReservations reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.Id == 0)
                {
                    _db.ClubReservationses.Add(new ClubReservations()
                    {
                        
                        ApplicationUserId = ApplicationUserService.GetUserId(),
                        EndDate = reservation.EndDate,
                        ClubId = reservation.ClubId,
                        PaymentType = reservation.PaymentType,
                        StartDate = reservation.StartDate,
                        ReservationDate = DateTime.Now,
                    });
                    _db.SaveChanges();
                    var body =
                        $"{MailService.HandleTwo(FileService.ReadFile(Server.MapPath("~/Files/Emails/2.txt")), new ClubReservations() { EndDate = reservation.EndDate, PaymentType = reservation.PaymentType, StartDate = reservation.StartDate, ReservationDate = DateTime.Now, ApplicationUser = ApplicationUserService.GetUser(), Club = _db.Clubs.FirstOrDefault(l => l.Id == reservation.ClubId), })}";
                    MailService.SendMail(Services.ApplicationUserService.GetUser().Email,
                        "Booking Confirmation", body);
                    return View("BookingConfirm");
                }
                else
                {
                    var currentUser = ApplicationUserService.GetUserId();
                    var ClubRes = _db.ClubReservationses.FirstOrDefault(l =>
                        l.Id == reservation.Id && l.ApplicationUserId == currentUser);
                    if (ClubRes != null)
                    {

                        ClubRes.EndDate = reservation.EndDate;
                        ClubRes.ClubId = reservation.ClubId;
                        ClubRes.PaymentType = reservation.PaymentType;
                        ClubRes.StartDate = reservation.StartDate;
                        _db.Entry(ClubRes).State = EntityState.Modified;
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Profile", "Manage");
                }
            }

            return RedirectToAction("Booking", new { Room = reservation.ClubId });
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
            return PartialView("_BookingClub", new ClubReservations()
            {
                Club = _db.Clubs.FirstOrDefault(l => l.Id == Room),
                Id = 0,
                StartDate = DateTime.Today,
                ApplicationUserId = Services.ApplicationUserService.GetUserId(),
                ClubId = Room,
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
            var ClubRoom = _db.ClubReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (ClubRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ClubRoom);
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult Checkin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var currentUser = ApplicationUserService.GetUserId();
            var ClubRoom = _db.ClubReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (ClubRoom == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ClubRoom);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.All)]
        [ValidateAntiForgeryToken]
        public ActionResult Checkin(int CheckId)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var ClubRes = _db.ClubReservationses.FirstOrDefault(l =>
                l.Id == CheckId && l.ApplicationUserId == currentUser);
            if (ClubRes != null)
            {

                ClubRes.IsCheckIn = !ClubRes.IsCheckIn;
                _db.Entry(ClubRes).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }

        [Authorize(Roles = RoleName.All)]
        public ActionResult DeleteBooking(int id)
        {

            var currentUser = ApplicationUserService.GetUserId();
            var ClubRes = _db.ClubReservationses.FirstOrDefault(l =>
                l.Id == id && l.ApplicationUserId == currentUser);
            if (ClubRes != null)
            {
                _db.Entry(ClubRes).State = EntityState.Deleted;
                _db.SaveChanges();
            }

            return RedirectToAction("Profile", "Manage");
        }
    }
}
