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
            
            return View(db.Shop.Find(1));
        }
    }
}