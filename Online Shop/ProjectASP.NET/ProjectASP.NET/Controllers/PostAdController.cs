using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProjectASP.NET.Models;

namespace ProjectASP.NET.Controllers
{
    public class PostAdController : Controller
    {
        //
        // GET: /PostAd/
        
        public ActionResult Index()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Index(Item item)
        {
            if (ModelState.IsValid)
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    try
                    {
                        item.SellerUsername = Session["username"].ToString();
                        item.Posted = DateTime.Now;
                        item.Price = Convert.ToDouble(item.Price);
                        db.Items.AddObject(item);
                        db.SaveChanges();
                        Session["tempitemid"] = item.ItemID;
                        return RedirectToAction("ImageUpload", "PostAd");
                    }
                    catch (Exception)
                    {
                        return View();
                    }
                }
            }
            else
                return View();
        }
        public ActionResult ImageUpload()
        {
            if (Session["tempitemid"] == null)
                return RedirectToAction("Index", "PostAd");
            else
                return View();
        }
        [HttpPost]
        public ActionResult ImageUpload(FileUploadViewModel FileModel, string submit)
        {
            if (submit.Equals("Skip"))
            {
                return RedirectToAction("Success", "PostAd");
            }
            else
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    FileUploadService service = new FileUploadService();
                    foreach (var item in FileModel.file)
                    {
                        service.SaveFileDetails(item, Convert.ToInt32(Session["tempitemid"].ToString()));
                    }
                    return RedirectToAction("Success", "PostAd");
                }
            }
        }
        public ActionResult Success()
        {
            if (Session["tempitemid"] == null)
                return RedirectToAction("Index", "PostAd");
            else
                return View();
        }

    }
}
