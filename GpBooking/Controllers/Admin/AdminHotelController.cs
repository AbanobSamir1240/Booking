using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GpBooking.Models;

namespace GpBooking.Controllers.Admin
{
    [Authorize(Roles = RoleName.Admin)]
    public class AdminHotelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminHotel
        public ActionResult Index()
        {
            return View(db.Hotels.ToList());
        }

        // GET: AdminHotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: AdminHotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminHotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,Rating,About")]
            Hotel hotel, [Bind(Include = "Img")] HttpPostedFileBase Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null)
                {

                    string extension = Path.GetExtension(Img.FileName);
                    string path = "~/Attachments";
                    string name =
                        $"{Path.GetFileNameWithoutExtension(Img.FileName)}{DateTime.Now.ToLongDateString()}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
                    string attachmentName = $"{name}{extension}";
                    string fileName = Path.Combine(Server.MapPath(path), attachmentName);
                    Img.SaveAs(fileName);
                    hotel.Image = $"/Attachments/{attachmentName}";
                }

                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: AdminHotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: AdminHotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,Rating,About")]
            Hotel hotel, [Bind(Include = "Img")] HttpPostedFileBase Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null)
                {

                    string extension = Path.GetExtension(Img.FileName);
                    string path = "~/Attachments";
                    string name =
                        $"{Path.GetFileNameWithoutExtension(Img.FileName)}{DateTime.Now.ToLongDateString()}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
                    string attachmentName = $"{name}{extension}";
                    string fileName = Path.Combine(Server.MapPath(path), attachmentName);
                    Img.SaveAs(fileName);
                    hotel.Image = $"/Attachments/{attachmentName}";
                }
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: AdminHotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: AdminHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
