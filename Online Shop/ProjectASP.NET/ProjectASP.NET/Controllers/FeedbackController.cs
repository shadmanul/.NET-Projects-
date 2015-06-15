using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/

        public ActionResult Index(int? page)
        {
            if (Convert.ToString(Session["status"]).Equals("Admin"))
            {
                ProjectDatabaseContext db = new ProjectDatabaseContext();
                var q = from p in db.Feedbacks
                        orderby p.Time descending
                        select p;

                return View(q.ToList().ToPagedList(page ?? 1, 8));
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["status"]).Equals("Admin"))
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    Feedback fb = db.Feedbacks.SingleOrDefault(e => e.Id == id);
                    db.Feedbacks.DeleteObject(fb);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Feedback");
                }
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
