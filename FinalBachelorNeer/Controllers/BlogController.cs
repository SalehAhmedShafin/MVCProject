using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBachelorNeer.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult BlogIndex()
        {
            if (Session["users"] != null)
                return View();

            return RedirectToAction("AdvanceSignin", "Signin");
        }
    }
}