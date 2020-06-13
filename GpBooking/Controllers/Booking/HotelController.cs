using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GpBooking.Models;

namespace GpBooking.Controllers.Booking
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _db ;

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

        /*
        // GET: Hotel
        public ActionResult Index()
        {
            return View(_db.Hotels.ToList());
        }
        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,Rating,About,Image")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Hotels.Add(hotel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,Rating,About,Image")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(hotel).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = _db.Hotels.Find(id);
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
