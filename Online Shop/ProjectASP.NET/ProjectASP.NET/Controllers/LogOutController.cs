using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class LogOutController : Controller
    {
        //
        // GET: /LogOut/

        public ActionResult Index()
        {
            Session["username"] = null;
            Session["password"] = null;
            Session["status"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
