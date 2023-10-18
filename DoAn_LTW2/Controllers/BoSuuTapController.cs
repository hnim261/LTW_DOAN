using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW2.Models;
namespace DoAn_LTW2.Controllers
{
    public class BoSuuTapController : Controller
    {
        // GET: BoSuuTap
        public ActionResult Collection(string search = "")
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            //List<product> products = db.products.ToList();
            List<product> products = db.products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(products);
        }
        public ActionResult Detail(int id)
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            product pro = db.products.Where(row => row.Id == id).FirstOrDefault();
            return View(pro);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(product p1)
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            db.products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Collection");
        }
        public ActionResult Edit(int id)
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            product prod = db.products.Where(row => row.Id == id).FirstOrDefault();
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(product pro)
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            product prod = db.products.Where(row => row.Id == pro.Id).FirstOrDefault();
            //Update
            prod.ProductName = pro.ProductName;
            prod.Price = pro.Price;
            prod.Description = pro.Description;
            prod.image = pro.image;
            db.SaveChanges();
            return RedirectToAction("index");
        }
       public ActionResult Delete(int id)
        {
            DB_FirstEntities1 db = new DB_FirstEntities1();
            product pro = db.products.Where(row => row.Id == id).FirstOrDefault();
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}