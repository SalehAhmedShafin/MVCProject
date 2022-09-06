using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalBachelorNeer.Controllers
{
    public class UserprofileController : Controller
    {
        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        // GET: Userprofile


        

       
        public ActionResult UserIndex()
        {
            if (Session["users"] != null)
            {
                var viewbag = Session["users"];

                List<Approvedproperty> books = db.Approvedproperties.Where(temp => temp.ap_Email == viewbag).ToList();
                return View(books);
            }
            return RedirectToAction("AdvanceSignin", "Signin");
        }
        [HttpPost]

        public ActionResult UserIndex([Bind(Include = "ap_Name,ap_Email,ap_Number,ap_Type,ap_Proaddress,ap_Thana,ap_Imfile,ap_Rent,ap_Bed,ap_Bath,ap_Kitchen,ap_Belcony,ap_Dinning")] Approvedproperty pd)
        {
            if (ModelState.IsValid)
            {
                db.Approvedproperties.Add(pd);
                db.SaveChanges();
                return RedirectToAction("Congratulation", "AddProperty");

            }
            else
                return RedirectToAction("Error", "ErrorMessage");
        }
    }
}