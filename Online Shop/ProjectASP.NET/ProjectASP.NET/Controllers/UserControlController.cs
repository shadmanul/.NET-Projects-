using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class UserControlController : Controller
    {
        //
        // GET: /UserControl/

        
        [HttpGet]
        public ActionResult Index(string search, int? page)
        {
            if (Convert.ToString(Session["status"]).Equals("Admin"))
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    if (search != null)
                    {
                        var q = from p in db.Contacts
                                where p.Username.Contains(search) || p.Email.Contains(search)
                                select p;
                        return View(q.ToList().ToPagedList(page ?? 1, 6));
                    }
                    else
                        return View(db.Contacts.ToList().ToPagedList(page ?? 1, 6));
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Delete(string id)
        {
            if (Convert.ToString(Session["status"]).Equals("Admin"))
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    try
                    {
                        var d = from p in db.Comments
                                where p.Username.Equals(id)
                                select p;
                        foreach (var i in d)
                        {
                            db.Comments.DeleteObject(i);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        int q = (from p in db.Items
                                 where p.SellerUsername == id
                                 select p.ItemID).FirstOrDefault();
                        var ii = from p in db.ItemImages
                                 where p.ItemID == q
                                 select p;
                        foreach (var i in ii)
                        {
                            db.ItemImages.DeleteObject(i);
                        }
                        db.SaveChanges();
                        Item item = db.Items.Single(e => e.SellerUsername == id);
                        db.Items.DeleteObject(item);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                    }

                    Contact contact = db.Contacts.Single(e => e.Username == id);
                    db.Contacts.DeleteObject(contact);
                    db.SaveChanges();
                    LoginInfo login = db.LoginInfos.Single(e => e.Username == id);
                    db.LoginInfos.DeleteObject(login);
                    db.SaveChanges();

                    return RedirectToAction("Index","UserControl",db.Contacts.ToList());
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Promote(string id)
        {
            if (Convert.ToString(Session["status"]).Equals("Admin"))
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    var q = (from p in db.LoginInfos
                             where p.Username == id
                             select p).FirstOrDefault();
                    return View(q);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Promote(LoginInfo log)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.LoginInfos.Attach(log);
                        db.ObjectStateManager.ChangeObjectState(log, System.Data.EntityState.Modified);
                        db.SaveChanges();
                        return RedirectToAction("Index","UserControl");
                    }
                    else
                    {
                        return RedirectToAction("Index","UserControl");
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }
        }
    }
}
