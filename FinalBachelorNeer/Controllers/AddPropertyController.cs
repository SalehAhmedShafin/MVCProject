using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace DemoBachelorNeer.Controllers
{
    public class AddPropertyController : Controller
    {
        // GET: AddProperty

        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        public ActionResult AddPropertyIndex()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }

        

        //[HttpPost]
        //public ActionResult AddPropertyDetails([Bind(Include = "up_Name,up_Email,up_Number,up_Type,up_Proaddress,up_Thana,up_Imfile,up_Rent")] PropertyDetail pd)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.PropertyDetails.Add(pd);
        //        db.SaveChanges();
        //        return RedirectToAction("AddPropertyDetails", "AddProperty");

        //    }
        //    ViewBag.messege = "Something Error!";
        //    return View();
        //}



        public ActionResult AdvanceDetailsForm()
        {
            if (Session["users"] != null)
            {
                var viewbag = Session["users"];

                List<userinfo> books = db.userinfoes.Where(temp => temp.u_Email == viewbag).ToList();
                return View(books);
            }

            return RedirectToAction("AdvanceSignin", "Signin");
        }



        //[HttpPost]


        //public ActionResult AdvanceDetailsForm( var u_Name )
        //{
           


        //        var viewbag = Session["users"];

        //        List<userinfo> books = db.userinfoes.Where(temp => temp.u_Email == viewbag).ToList();
        //        return View(books);
        //    }
           
        //}


        [HttpPost]

        public ActionResult AdvanceDetailsForm(string up_Number,[Bind(Include = "up_Name,up_Email,up_Number,up_Type,up_Proaddress,up_Thana,up_Imfile,up_Rent")] PropertyDetail pd)
        {
           var phoneno = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (!Regex.IsMatch(up_Number, phoneno))
                @ViewBag.ConError = "Number is not correct";


            if (ModelState.IsValid)
            {

                db.PropertyDetails.Add(pd);
                db.SaveChanges();
                return RedirectToAction("Congratulation", "AddProperty");

            }


            ViewBag.messege = "Something Error!";
            return View();
        }


       

        public ActionResult Congratulation()
        {
            return View();
        }
    }
}