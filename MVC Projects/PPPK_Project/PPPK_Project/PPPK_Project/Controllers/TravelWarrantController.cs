using PPPK_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPPK_Project.Controllers
{
    public class TravelWarrantController : Controller
    {
        // GET: TravelWarrant
        public ActionResult AllTravelWarrants()
        {
            return View((object)DBHelper.getAllTravelWarrants());
        }

        public ActionResult TravelWarrant(int? id)
        {
            try
            {
                return View((object)DBHelper.getTravelWarrant((int)id));
            }
            catch (Exception)
            {

                return View((object)null);
            }

        }

        [HttpGet]
        public ActionResult InsertTravelWarrant()
        {
            ViewBag.Driver = DropdownHelper.DriversDropDown();
            ViewBag.Vehicle = DropdownHelper.VehiclesDropDonw();
            ViewBag.Status = DropdownHelper.ServicesDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTravelWarrant(DateTime starting_date, DateTime ending_date, string driver_id, string vehicle_id)
        {
            DBHelper.insertTravelWarrant(starting_date, ending_date, Convert.ToInt32(driver_id), Convert.ToInt32(vehicle_id));
            return View("AllTravelWarrants");
        }
    }
}