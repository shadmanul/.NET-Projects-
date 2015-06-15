using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectASP.NET.Models;
using PagedList;
using PagedList.Mvc;


namespace ProjectASP.NET.Controllers
{
    public class ItemListController : Controller
    {
        //
        // GET: /ItemList/

        public ActionResult Index(string id, string title, string location, string category, string price, int? page)
        {
            if (title != null || location != null || category != null || price != null)
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    if (title == null)
                    {
                        title = "";
                    }
                    if (location == null)
                    {
                        location = "";
                    }
                    if (category == null)
                    {
                        category = "";
                    }
                    if (price == null)
                    {
                        price = "";
                    }
                    double cprice;
                    if (price == "")
                    {
                        cprice = 10000000000000;
                    }
                    else
                    {
                        cprice = Convert.ToDouble(price);
                    }
                    
                    var q = from p in db.Items
                            where p.ItemTitle.Contains(title) && p.Location.Contains(location)
                            && p.Category.Contains(category) && p.Price <= cprice
                            orderby p.ItemID descending
                            select p;
                    return View(q.ToList().ToPagedList(page ?? 1, 8));
                }
            }
            else
            {
                using (ProjectDatabaseContext db = new ProjectDatabaseContext())
                {
                    if (id != null)
                    {
                        var q = from p in db.Items
                                where p.SellerUsername == id
                                orderby p.ItemID descending
                                select p;
                        return View(q.ToList().ToPagedList(page ?? 1, 8));
                    }
                    else
                    {
                        var q = from p in db.Items
                                orderby p.ItemID descending
                                select p;
                        return View(q.ToList().ToPagedList(page ?? 1, 8));
                    }
                }
            }
        }

        //[HttpPost]
        //public ActionResult Index(FormCollection col)
        //{
        //    using (ProjectDatabaseContext db = new ProjectDatabaseContext())
        //    {
        //        double price;
        //        string title = col["title"];
        //        string location = col["location"];
        //        string category = col["category"];
        //        if (col["price"] == "")
        //        {
        //            price = 10000000000000;
        //        }
        //        else
        //        {
        //            price = Convert.ToDouble(col["price"]);
        //        }
        //        var q = from p in db.Items
        //                where p.ItemTitle.Contains(title) && p.Location.Contains(location)
        //                && p.Category.Contains(category) && p.Price <= price
        //                orderby p.ItemID descending
        //                select p;
        //        return View(q.ToList());
        //    }
        //}

        public ActionResult Category(string id, int? page)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                if (id != null)
                {
                    var q = from p in db.Items
                            where p.Category == id
                            select p;
                    return View("Index", q.ToList().ToPagedList(page ?? 1, 8));
                }
                else
                    return View("Index", db.Items.ToList().ToPagedList(page ?? 1, 8));
            }
        }
        
        
        public ActionResult Result(string topsearch,int? page)
        {
            using (ProjectDatabaseContext db = new ProjectDatabaseContext())
            {
                var q = from p in db.Items
                        where p.ItemTitle.Contains(topsearch)
                        select p;
                return View("Index", q.ToList().ToPagedList(page ?? 1, 8));
            }
            
        }

    }
}
