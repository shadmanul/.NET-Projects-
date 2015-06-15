using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.NET;
using System.IO;

namespace ProjectASP.NET.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Ragistration/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginInfo log, string confirm)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (confirm != null && log.Password.Equals(confirm))
                    {
                        using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                        {
                            int count = (from p in db.LoginInfos
                                         where p.Username == log.Username
                                         select p).Count();
                            if (count == 0)
                            {
                                Session["tempuser"] = log.Username;
                                log.Status = "Member";
                                db.LoginInfos.AddObject(log);
                                db.SaveChanges();
                            }
                            else
                            {
                                ViewBag.Msg = "<span align='center'>Username Taken</span><br /><br />";
                                return View();
                            }
                        }
                        return RedirectToAction("PersonalInfo", "Registration");
                    }
                    else
                    {
                        ViewBag.Msg = "<span align='center'>Password Didn't Match</span><br /><br />";
                        return View();
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
                return View();
            
        }
        //
        // POST: /Registration/Create

        public ActionResult PersonalInfo()
        {
            if (Session["tempuser"] == null)
                return RedirectToAction("Index", "Registration");
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult PersonalInfo(Contact contact, HttpPostedFileBase FileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.Username = Session["tempuser"].ToString();

                    using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                    {
                        if (FileUpload != null)
                        {
                            if (FileUpload.ContentLength < (1024 * 1024) && (FileUpload.ContentType.Contains("/jpg") || FileUpload.ContentType.Contains("/jpeg") || FileUpload.ContentType.Contains("/png") || FileUpload.ContentType.Contains("/bmp")))
                            {
                                contact.ImageContentType = FileUpload.ContentType;
                                contact.ImageBytes = ConverToByte(FileUpload);
                                ViewBag.Msg = null;
                            }
                            else
                            {
                                ViewBag.Msg = "<span align='center'>Invalid File</span><br /><br />";
                            }
                        }
                        if (ViewBag.Msg == null)
                        {
                            db.Contacts.AddObject(contact);
                            db.SaveChanges();
                            return RedirectToAction("Success", "Registration");
                        }
                        else
                        {
                            return View();
                        }
                    }

                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
                return View();
            
        }

        private byte[] ConverToByte(HttpPostedFileBase file)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            imageBytes = reader.ReadBytes((int)file.ContentLength);
            return imageBytes;
        }
        public ActionResult Success()
        {
            if (Session["tempuser"] == null)
                return RedirectToAction("Index", "Registration");
            else
            {
                return View();
            }
            
        }

    }
}
