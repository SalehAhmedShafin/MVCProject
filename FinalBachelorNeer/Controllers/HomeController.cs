using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBachelorNeer.Controllers
{
    
    public class HomeController : Controller
    {

        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        public ActionResult Index()
        {
            if (Session["users"] != null)
            {
                
                return View();

            }



            return RedirectToAction("AdvanceSignin", "Signin");
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            
                List<PropertyDetail> pd = db.PropertyDetails.Where(temp => temp.up_Thana.Contains(search)).ToList();

                return RedirectToAction("Properties", "PropertyDetails", pd);

          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }
        public ActionResult BeforeLogin()
        {
            Session["users"] = null;
            return View();
        }

      

       
    }
}