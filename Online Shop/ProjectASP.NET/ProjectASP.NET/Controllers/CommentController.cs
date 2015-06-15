using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Index(int id)
        {
            Session["tempid"] = id;
            using(ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                var q = from p in db.Comments
                        where p.ItemID == id
                        select p;
                return View(q.ToList());
            }
        }

        public ActionResult DeleteComment(int id)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                string itemid = Convert.ToString(Session["tempid"]);
                Comment q = (from p in db.Comments
                            where p.CommentID == id
                            select p).FirstOrDefault();
                db.Comments.DeleteObject(q);
                db.SaveChanges();
                return RedirectToAction("Index", new {id=itemid });
            }
        }
    }
}
