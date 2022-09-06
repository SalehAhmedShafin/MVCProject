using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalBachelorNeer.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup

        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        public ActionResult UserCreateAccount()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserCreateAccount([Bind(Include = "u_Name, u_Number, u_Email, u_NID, u_Password")] userinfo user)
        {
            
            if (ModelState.IsValid)
            {

                db.userinfoes.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Signin");

            }
            ViewBag.Error = "Account Create Failed";
            return View();
        }
        public ActionResult AdvanceSignup()
        {

            return View();
        }


        [HttpPost]


        public ActionResult AdvanceSignup(String u_Email, String u_Number, String u_NID, [Bind(Include = "u_Name, u_Number, u_Email, u_NID, u_Password,u_ConPassword")] userinfo user)
        {
            try
            {

                var pd = db.userinfoes.Where(temp => temp.u_Email.Contains(u_Email)).ToList();
                var pd1 = db.userinfoes.Where(temp => temp.u_Number.Contains(u_Number)).ToList();
                var pd2 = db.userinfoes.Where(temp => temp.u_NID.Contains(u_NID)).ToList();

                if (pd.Count > 0)
                {
                    ViewBag.ErrorMessages = "This Email already Used";
                }
                if (pd1.Count > 0)
                {
                    ViewBag.ErrorMessagesss = "This Number already Used";
                }
                if (pd2.Count > 0)
                {
                    ViewBag.ErrorMessagess = "This NID already Used";
                }

                else
                {
                    if (ModelState.IsValid)
                    {

                        db.userinfoes.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("AdvanceSignin", "Signin");
                    }
                    

                }

               
            }
            catch(Exception exception)
            {
                ViewBag.Valid = "Fill Up this form carefully";
                
               // return RedirectToAction("Error", "ErrorMessage");

            }
           return View();
        }
    }
}