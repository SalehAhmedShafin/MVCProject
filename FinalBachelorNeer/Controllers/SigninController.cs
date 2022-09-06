using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBachelorNeer.Controllers
{
    public class SigninController : Controller
    {
        // GET: Signin

        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult login(userinfo user)
        {
            

            using (var context = new bachelorNeerEntities2())
            {
                
                bool valid = context.userinfoes.Any(temp => temp.u_Email == user.u_Email && temp.u_Password == user.u_Password);
               
                if (valid)
                {
                    Session["users"] = user.u_Email;
                    
                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.errorMessege = "Log in failed";
                    return View();
                }

            }

           
            
        }
        public ActionResult AdvanceSignin()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AdvanceSignin(String Usersss, String Admin, String u_Email, userinfo user)
        {
            //var Admin = Request.Form.GetValues("Admin");
            //var Users = Request.Form.GetValues("User");
            //System.Diagnostics.Debug.WriteLine("user  " + Userss + " admin   " + Admin);

            if (Usersss == null && Admin == null)
            {
                //System.Diagnostics.Debug.WriteLine(Userss+Admin);
                ViewBag.ValidSign = "Select User or Admin!";
            }
            else if(Usersss != null && Admin == null)
            {
                System.Diagnostics.Debug.WriteLine("usernew  "+Usersss+" adminnwe   " + Admin);
                var pdd = db.userinfoes.Where(temp => temp.u_Email.Contains(u_Email)).ToList();
                    if (pdd.Count == 0)
                        ViewBag.ValidSign = "You have no Account! Create account First";

                    else 
                    {

                        using (var context = new bachelorNeerEntities2())
                        {

                            //try
                            //{
                                
                            bool valid = context.userinfoes.Any(temp => temp.u_Email == user.u_Email && temp.u_Password == user.u_Password);
                            //String a = user.u_Email;
                            //String aa = new string(a.ToCharArray().Reverse().ToArray());
                            //aa.Reverse();
                            //String bb = "moc.liamg.reen";
                            //int i = 0, flag = 1;
                            //System.Diagnostics.Debug.WriteLine(aa);
                            //foreach (var temp in bb)
                            //{
                            //    if (temp != aa[i])
                            //    {
                            //        flag = 0;
                            //        break;
                            //    }
                            //    i++;
                            //}
                            if (valid)
                                {
                                    System.Diagnostics.Debug.WriteLine("Successs");
                                     Session["users"] = user.u_Email;
                                     return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                    ViewBag.ValidSign = "Log in failed";
                                    return View();
                                }
                            
                            //catch (Exception exception)
                            //{

                            //}

                        }
                       
                    }
                
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("user  " + Usersss + " admin   " + Admin);
                var pdd = db.userinfoes.Where(temp => temp.u_Email.Contains(u_Email)).ToList();
                if (pdd.Count == 0)
                    ViewBag.ValidSign = "You have no Account! Create account First";

                else
                {

                    using (var context = new bachelorNeerEntities2())
                    {
                        try
                        {
                            bool valid = context.userinfoes.Any(temp => temp.u_Email == user.u_Email && temp.u_Password == user.u_Password);
                            String a = user.u_Email;
                            String aa=new string(a.ToCharArray().Reverse().ToArray());
                            aa.Reverse();
                            String bb = "moc.liamg.reen";
                            int i = 0,flag=1;
                            //System.Diagnostics.Debug.WriteLine(aa);
                            foreach (var temp in bb)
                            {
                                if (temp != aa[i])
                                {
                                    flag = 0;
                                    break;
                                }
                                i++;
                            }
                            if (valid && flag==1)
                            {
                                
                                
                                
                                Session["admin"] = user.u_Email;
                                return RedirectToAction("Admindashboard", "Admin");
                            }
                            else
                            {
                                ViewBag.ValidSign = "Log in failed";
                                return View();
                            }
                        }
                        catch (Exception exception)
                        {
                            ViewBag.ValidSign = "Error";
                        }

                    }
                    return View();
                }
            }

          return View();
        }
        
    }
}