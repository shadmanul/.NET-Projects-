using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProjectASP.NET.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index(string id = null)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                if (id != null)
                {
                    var q = (from p in db.Contacts
                             where p.Username == id
                             select p).FirstOrDefault();
                    return View(q);
                }
                else
                {
                    if (Session["username"] != null)
                    {
                        string username = Session["username"].ToString();
                        var q = (from p in db.Contacts
                                 where p.Username == username
                                 select p).FirstOrDefault();
                        return View(q);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        public ActionResult EditProfile()
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                if (Session["username"] != null)
                {
                    string username = Session["username"].ToString();
                    var q = (from p in db.Contacts
                             where p.Username == username
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
        public ActionResult EditProfile(Contact con)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Contacts.Attach(con);
                        db.ObjectStateManager.ChangeObjectState(con, System.Data.EntityState.Modified);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string username = Session["username"].ToString();
                        var q = (from p in db.Contacts
                                 where p.Username == username
                                 select p).FirstOrDefault();
                        return View(q);
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