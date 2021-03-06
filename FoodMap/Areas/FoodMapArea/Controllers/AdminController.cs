﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodMap.Areas.FoodMapArea.Models;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FoodMap.Areas.FoodMapArea.Controllers
{
    public class AdminController : Controller
    {
        
        private superuniversityEntities db = new superuniversityEntities();
        // GET: FoodMapArea/Admin
        public ActionResult Index()
        {
            return View(db.Shop.ToList());
        }

        public ActionResult GetImage(int id = 1)
        {
            Shop shop = db.Shop.Find(id);
            byte[] img = shop.BytesImage1;
            return File(img, "image/jpeg");
        }

        public ActionResult GetImage2(int id = 1)
        {
            
            Shop shop = db.Shop.Find(id);
            byte[] img = shop.BytesImage2;
            return File(img, "image/jpeg");

        }

        public ActionResult GetImage3(int id = 1)
        {
            Shop shop = db.Shop.Find(id);
            byte[] img = shop.BytesImage3;
            return File(img, "image/jpeg");

        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.datas = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            //var school = from p in db.School
            //             where p.CityID == cityid
            //             join d in db.City
            //             on p.CityID  equals  d.CityID 
            //             select  p;
            return View();
        }

    


        [HttpPost]
        public ActionResult Create(Shop shop, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            if(Image1 != null)
            {
                string strPath1 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image1.FileName;
                Image1.SaveAs(strPath1);
                var imgSize1 = Image1.ContentLength;
                byte[] imgByte1 = new byte[imgSize1];
                Image1.InputStream.Read(imgByte1, 0, imgSize1);
                shop.Image1 = Image1.FileName;
                shop.BytesImage1 = imgByte1;


                if (Image2 != null)
                {
                    string strPath2 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image2.FileName;
                    Image2.SaveAs(strPath2);
                    var imgSize2 = Image2.ContentLength;
                    byte[] imgByte2 = new byte[imgSize2];
                    Image2.InputStream.Read(imgByte2, 0, imgSize2);
                    shop.Image2 = Image2.FileName;
                    shop.BytesImage2 = imgByte2;
                }


                if (Image3 != null)
                {
                    string strPath3 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image3.FileName;
                    Image3.SaveAs(strPath3);
                    var imgSize3 = Image3.ContentLength;
                    byte[] imgByte3 = new byte[imgSize3];
                    Image3.InputStream.Read(imgByte3, 0, imgSize3);
                    shop.Image3 = Image3.FileName;
                    shop.BytesImage3 = imgByte3;
                }



                db.Shop.Add(shop);
                db.SaveChanges();

                return RedirectToAction("Index", "Admin", new { Area = "FoodMapArea" });
            }
            ViewBag.Message = "請至少選擇一張圖片";
            ViewBag.datas = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            return View();

        }

        public ActionResult Detail(int id=0)
        {
            ViewBag.datas = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            ViewBag.number = id;
            ViewBag.image2 = db.Shop.Find(id).Image2;
            ViewBag.image3 = db.Shop.Find(id).Image3;
            return View(db.Shop.Find(id));
        }

        [HttpGet]
        public ActionResult Update(int id=0)
        {
            ViewBag.datas = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            return View(db.Shop.Find(id));
        }



        [HttpPost]
        public ActionResult Update(Shop shop, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {

            if (Image1 != null)
            {
                string strPath1 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image1.FileName;
                Image1.SaveAs(strPath1);
                var imgSize1 = Image1.ContentLength;
                byte[] imgByte1 = new byte[imgSize1];
                Image1.InputStream.Read(imgByte1, 0, imgSize1);
                shop.Image1 = Image1.FileName;
                shop.BytesImage1 = imgByte1;


                if (Image2 != null)
                {
                    string strPath2 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image2.FileName;
                    Image2.SaveAs(strPath2);
                    var imgSize2 = Image2.ContentLength;
                    byte[] imgByte2 = new byte[imgSize2];
                    Image2.InputStream.Read(imgByte2, 0, imgSize2);
                    shop.Image2 = Image2.FileName;
                    shop.BytesImage2 = imgByte2;
                }


                if (Image3 != null)
                {
                    string strPath3 = Request.PhysicalApplicationPath + @"Areas/FoodMapArea/ShopImages/" + Image3.FileName;
                    Image3.SaveAs(strPath3);
                    var imgSize3 = Image3.ContentLength;
                    byte[] imgByte3 = new byte[imgSize3];
                    Image3.InputStream.Read(imgByte3, 0, imgSize3);
                    shop.Image3 = Image3.FileName;
                    shop.BytesImage3 = imgByte3;
                }



                db.Entry(shop).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Admin", new { Area = "FoodMapArea" });
            }
            ViewBag.Message = "請至少選擇一張圖片";
            ViewBag.datas = db.FoodCategory.ToList();
            ViewBag.cities = db.City.ToList();
            ViewBag.schools = db.School.ToList();
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            DialogResult result = MessageBox.Show("是否確定刪除此筆資料?", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.Shop.Remove(db.Shop.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index", "Admin", new { Area = "FoodMapArea" });
            }
            return RedirectToAction("Index", "Admin", new { Area = "FoodMapArea" });
        }
    }
}