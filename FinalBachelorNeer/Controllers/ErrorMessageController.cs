using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalBachelorNeer.Controllers
{
    public class ErrorMessageController : Controller
    {
        // GET: ErrorMessage
        public ActionResult Error()
        {
            return View();
        }
    }
}