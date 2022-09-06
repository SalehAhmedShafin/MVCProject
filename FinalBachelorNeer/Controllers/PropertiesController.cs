using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBachelorNeer.Controllers
{
    public class PropertiesController : Controller
    {
        // GET: Property


        public ActionResult PropertyIndex()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin"); 
        }

        public ActionResult PropertyDetails()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }
    }
}