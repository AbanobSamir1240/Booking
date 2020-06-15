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
    public class AdminPlaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPlace
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        // GET: AdminPlace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }

            return View(place);
        }

        // GET: AdminPlace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPlace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,Name,About")]
            Place place, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    place.Image = $"/Attachments/{attachmentName}";
                }

                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: AdminPlace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }

            return View(place);
        }

        // POST: AdminPlace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,Name,About")]
            Place place, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    place.Image = $"/Attachments/{attachmentName}";
                }

                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: AdminPlace/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }

            return View(place);
        }

        // POST: AdminPlace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
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
