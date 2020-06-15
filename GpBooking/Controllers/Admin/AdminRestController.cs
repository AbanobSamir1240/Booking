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
    public class AdminRestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminRest
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        // GET: AdminRest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        // GET: AdminRest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,About")]
            Restaurant restaurant, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    restaurant.Image = $"/Attachments/{attachmentName}";
                }

                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: AdminRest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        // POST: AdminRest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,About")]
            Restaurant restaurant, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    restaurant.Image = $"/Attachments/{attachmentName}";
                }

                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: AdminRest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        // POST: AdminRest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
