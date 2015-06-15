using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class EditAdController : Controller
    {
        //
        // GET: /EditAd/

        public ActionResult Index(int id)
        {
            using(ProjectDatabaseContext db = new ProjectDatabaseContext()){

                string query = (from p in db.Items
                             where p.ItemID == id
                             select p.SellerUsername).FirstOrDefault();
                if (Convert.ToString(Session["username"]).Equals(query) || Convert.ToString(Session["status"]).Equals("Admin"))
                {
                    Item item = db.Items.Single(e => e.ItemID == id);
                    db.Items.DeleteObject(item);

                    var deleteItemImages = from p in db.ItemImages
                                           where p.ItemID == id
                                           select p;

                    foreach (var detail in deleteItemImages)
                    {
                        db.ItemImages.DeleteObject(detail);
                    }
                    db.SaveChanges();

                    string username = Convert.ToString(Session["username"]);

                    if (Convert.ToString(Session["status"]).Equals("Admin"))
                    {
                        return RedirectToAction("Index", "ItemList");
                    }
                    else
                    {
                        return RedirectToAction("Index", "ItemList", new { id = username });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult EditAdvertise(int id)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                string query = (from p in db.Items
                             where p.ItemID == id
                             select p.SellerUsername).FirstOrDefault();
                if (Convert.ToString(Session["username"]).Equals(query) || Convert.ToString(Session["status"]).Equals("Admin"))
                {
                    Session["tempid"] = id;
                    var q = (from p in db.Items
                             where p.ItemID == id
                             select p).FirstOrDefault();
                    return View(q);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        [HttpPost]
        public ActionResult EditAdvertise(Item item)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Items.Attach(item);
                        db.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Modified);
                        db.SaveChanges();
                        string username = Convert.ToString(Session["username"]);
                        if (Convert.ToString(Session["status"]).Equals("Admin"))
                        {
                            return RedirectToAction("Index", "ItemList");
                        }
                        else
                        {
                            return RedirectToAction("Index", "ItemList", new { id = username });
                        }
                    }
                    else
                    {
                        int id = Convert.ToInt32(Session["tempid"]);
                        var q = (from p in db.Items
                                 where p.ItemID == id
                                 select p).FirstOrDefault();
                        return View(q);
                    }
                }
                catch (Exception e)
                {
                    int id = Convert.ToInt32(Session["tempid"]);
                    var q = (from p in db.Items
                             where p.ItemID == id
                             select p).FirstOrDefault();
                    return View(q);
                }
            }
        }

    }
}
