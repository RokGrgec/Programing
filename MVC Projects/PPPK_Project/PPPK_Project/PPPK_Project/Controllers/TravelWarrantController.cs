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

    }
}