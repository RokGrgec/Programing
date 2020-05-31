using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPPK_Project.Models;

namespace PPPK_Project.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InsertDriver()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDriver(Driver d)
        {
            if (ModelState.IsValid)
            {
                DBHelper.insertDriver(d.Name, d.Surname, d.PhoneNumber, d.DriverLicenceNumber);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}