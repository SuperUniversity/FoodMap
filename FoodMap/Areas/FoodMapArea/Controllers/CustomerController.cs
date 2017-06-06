using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodMap.Areas.FoodMapArea.Models;

namespace FoodMap.Areas.FoodMapArea.Controllers
{
    public class CustomerController : Controller
    {
        private superuniversityEntities db = new superuniversityEntities();
        // GET: FoodMapArea/Customer

        
        public ActionResult Index()
        {
            Random r = new Random();
            ViewBag.num = r.Next(3, 8);
            return View(db.Shop.Find(ViewBag.num));
        }

        public ActionResult GetImage(int id = 1)
        {
            
            Shop shop = db.Shop.Find(id);
            byte[] img = shop.BytesImage1;
            return File(img, "image/jpeg");
        }

        [HttpGet]
        public ActionResult Map()
        {
            
            
            ViewBag.categories = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            return View(db.Shop.ToList());
        }

       
        [HttpPost]
        public ActionResult Map(int CityID=1,int SchoolID=1,int FoodCategoryID=1)
        {
            var result = from p in db.Shop
                         where p.CityID == CityID && p.SchoolID == SchoolID && p.FoodCategoryID == FoodCategoryID
                         select p;
            return View(result.ToList());
            
        }

        public ActionResult PartialMap()
        {
            ViewBag.categories = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            return PartialView();
        }
    }
}