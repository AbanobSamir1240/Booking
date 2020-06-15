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
    public class AdminClubController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminClub
        public ActionResult Index()
        {
            return View(db.Clubs.ToList());
        }

        // GET: AdminClub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: AdminClub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminClub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,About")] Club club, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    club.Image = $"/Attachments/{attachmentName}";
                }
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        // GET: AdminClub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: AdminClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,Name,Address,Tel1,Tel2,About")] Club club, [Bind(Include = "Img")] HttpPostedFileBase Img)
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
                    club.Image = $"/Attachments/{attachmentName}";
                }
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: AdminClub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: AdminClub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
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
