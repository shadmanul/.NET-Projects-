using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GetImage(string id)
        {
            ProjectDatabaseContext db = new ProjectDatabaseContext();
            var q = from p in db.Contacts
                    where p.Username == id
                    select p;
            byte[] byteArray = q.FirstOrDefault().ImageBytes;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, q.FirstOrDefault().ImageContentType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetItemImage(int id)
        {
            ProjectDatabaseContext db = new ProjectDatabaseContext();

            var q = from p in db.ItemImages
                    where p.ItemID == id
                    select p;

            byte[] byteArray = q.FirstOrDefault().ImageBytes;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, q.FirstOrDefault().ContentType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetImages(int id)
        {
            ProjectDatabaseContext db = new ProjectDatabaseContext();

            var q = from p in db.ItemImages
                    where p.ID == id
                    select p;

            byte[] byteArray = q.FirstOrDefault().ImageBytes;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, q.FirstOrDefault().ContentType);
            }
            else
            {
                return null;
            }
        }

    }
}
