using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection Col)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                string username = Col["UsernameTB"];
                string password = Col["PasswordTB"];
                var query = from p in context.LoginInfos
                            where p.Username.Equals(username) && p.Password.Equals(password)
                            select p;
                var count = query.Count();
                if (count == 1)
                {
                    Session["username"] = query.FirstOrDefault().Username;
                    Session["password"] = query.FirstOrDefault().Password;
                    Session["status"] = query.FirstOrDefault().Status;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msg = "Incorrect Username/Password";
                    return View();
                }
            }
            
        }

    }
}
