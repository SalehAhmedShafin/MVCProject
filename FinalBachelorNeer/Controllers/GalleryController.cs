using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBachelorNeer.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult GalleryIndex()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }

        public ActionResult GalleryDetails()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }
    }
}