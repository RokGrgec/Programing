using DiabetesHelperUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesHelperUser.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(User user)
        {
            using (DBModel db = new DBModel())
            {
                var userValidation = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (userValidation == null)
                {
                    user.ErrorMessage = "Invalid username or password";
                    return View("Index", user);
                }
                else
                {
                    Session["Name"] = user.Name;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}