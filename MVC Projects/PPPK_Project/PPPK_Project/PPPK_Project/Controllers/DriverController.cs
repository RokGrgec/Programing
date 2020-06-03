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
        public ActionResult AllDrivers()
        {
            return View((object)DBHelper.getAllDrivers());
        }

        public ActionResult Driver(int? id)
        {
            try
            {
                return View((object)DBHelper.getDriver((int)id));
            }
            catch (Exception)
            {

                return View((object)null);
            } 
        }


       
        public ActionResult DeleteDriver(int id)
        {
            try
            {
                DBHelper.deleteDriver((int)id);
                return View();
            }
            catch (Exception)
            {
                return View();
            }
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
                return RedirectToAction("Index","Home");
            }
            return View();

        }
    }
}