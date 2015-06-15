using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class ItemProfileController : Controller
    {
        //
        // GET: /ItemProfile/

        public ActionResult Index(int id = 0)
        {
            if (id != 0)
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    var q = (from p in db.Items
                             where p.ItemID == id
                             select p).FirstOrDefault();
                    return View(q);
                }
            }
            else
                return RedirectToAction("Index", "ItemList");
            
        }
        public ActionResult ItemImage(int id = 0)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                var q = (from p in db.ItemImages
                         where p.ItemID == id
                         select p).ToList();
                return View(q);
            }
            
        }
        [HttpPost]
        public ActionResult Index(int itemid, string comment)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                Comment com = new Comment();
                com.ItemID = itemid;
                com.Username = Convert.ToString(Session["username"]);
                com.CommentMessage = comment;
                com.Time = DateTime.Now;
                db.Comments.AddObject(com);
                db.SaveChanges();

                return RedirectToAction("Index", "ItemProfile", new { id=itemid });
            }
        }
    }
}
