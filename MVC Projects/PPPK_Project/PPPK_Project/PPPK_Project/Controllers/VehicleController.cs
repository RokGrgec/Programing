using PPPK_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPPK_Project.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllVehicles()
        {
            return View((object)DBHelper.getAllVehicles());
        }
        public ActionResult Vehicle(int? id)
        {
            try
            {
                return View((object)DBHelper.getVehicle((int)id));
            }
            catch (Exception)
            {

                return View((object)null);
                
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DBHelper.deleteVehicle((int)id);
            return RedirectToAction("AllVehicles");
        }

        [HttpGet]
        public ActionResult InsertVehicle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertVehicle(Vehicle v)
        {
            if (ModelState.IsValid)
            {
                DBHelper.insertVehicle(v.VehicleBrand, v.VehicleType, Convert.ToDateTime(v.ProductionYear), Convert.ToInt32(v.StartingKilometers), Convert.ToInt32(v.CurrentKilometers));
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}