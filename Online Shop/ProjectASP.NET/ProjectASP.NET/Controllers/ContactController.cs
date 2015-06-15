using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {

                string subject = col["subjectTB"];
                string message = col["messageTB"];
                //DateTime time = DateTime.Now;
                Feedback fb = new Feedback();

                fb.Subject = subject;
                fb.Message = message;
                if (Session["username"] == null)
                    fb.Username = "Guest";
                else
                    fb.Username = Session["username"].ToString();
                fb.Time = DateTime.Now;

                db.Feedbacks.AddObject(fb);
                db.SaveChanges();


                return RedirectToAction("Success", "Contact");
            }
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}
