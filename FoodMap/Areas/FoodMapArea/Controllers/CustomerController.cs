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
    }
}