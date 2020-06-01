using PPPK_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPPK_Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BackupDB()
        {
            //DBHelper.BackupDb();
            return RedirectToAction("Index");
        }
        // TO DO
        public ActionResult CleanDB()
        {
            DBHelper.CleanDb();
            return RedirectToAction("Index");
        }

        public ActionResult RestoreDb()
        {
            DBHelper.RestoreDb();
            return RedirectToAction("Index");
        }
    }
}