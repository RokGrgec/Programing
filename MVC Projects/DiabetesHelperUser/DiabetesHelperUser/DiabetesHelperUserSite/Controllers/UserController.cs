using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DiabetesHelperUser.Models;

namespace DiabetesHelperUser.Controllers
{
    public class UserController : Controller
    {
        //Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST
        [HttpPost]
        public ActionResult Registration(User user)
        {
            bool state = false;
            string message = "";
            if (ModelState.IsValid)
            {
                #region //Email Exists
                var notUniqueEmail = EmailExists(user.Email);
                if (notUniqueEmail)
                {
                    ModelState.AddModelError("EmailExists", "Email already exists");
                    return View(user);
                }
                #endregion

                #region //testing
                //else if (user.Activity != "Mild" || user.Activity != "mild" || user.Activity != "Occasional" || user.Activity != "occasional" || user.Activity != "Regular" || user.Activity != "regular")
                //{
                //    ModelState.AddModelError("WrongActivityEntered", "Please Reenter Activity!");

                //}
                //else if (user.DiaType != 1 || user.DiaType != 2)
                //{
                //    ModelState.AddModelError("WrongDiabetesType", "Diabetes Type Must Be 1 or 2, please reenter your type");

                //}
                //else if (user.Gender != "Male" || user.Gender != "male" || user.Gender != "Female" || user.Gender != "female" )
                //{
                //    ModelState.AddModelError("WrongGender", "Pls Dont!");
                //}
                #endregion

                #region //Saving to db
                using (Database1Entities1 db = new Database1Entities1())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();

                        message = "Registration succesfully done!";
                        state = true;
                    }
                    #endregion
                
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = state;
            return View(user);
        }
        
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {

            using (Database1Entities1 db = new Database1Entities1())
            {

                   
                var userDetail = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (userDetail == null)
                {
                    user.ErrorMessage = "Invalid username or password!";
                    return View("Login", user);
                }
                else
                {
                    Session["Password"] = user.Password;
                    Session["Name"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }

            }
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

        //Email Verification on Registration
        [NonAction]
        public bool EmailExists(string Email)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                var validation = db.Users.Where(a => a.Email == Email).FirstOrDefault();
                return validation != null;
            }
        }
    }
}