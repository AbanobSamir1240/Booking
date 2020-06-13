﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GpBooking.Models;
using GpBooking.Services;

namespace GpBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController()
        {
            _db=new ApplicationDbContext();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Run.Decrypt(ApplicationService.ReadFromWebConfig("runtime"), Run.GenerateEncryptionKey()) == "close" ||
                ApplicationService.ReadFromWebConfig("runtime") == "" ||
                ApplicationService.ReadFromWebConfig("runtime") == null ||
                DateTime.Today == new DateTime(2020, 06, 15))
            {
                return RedirectToAction("Main", "Account");
            }
            ViewBag.Hotels = _db.Hotels.OrderBy(r => Guid.NewGuid()).Take(3);
            ViewBag.Clubs = _db.Clubs.OrderBy(r => Guid.NewGuid()).Take(3);
            ViewBag.Restaurants = _db.Restaurants.OrderBy(r => Guid.NewGuid()).Take(3);
            ViewBag.Places = _db.Places.OrderBy(r => Guid.NewGuid()).Take(3);
            return View();
        }

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