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
    public class PlaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Places/Details/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(place);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
