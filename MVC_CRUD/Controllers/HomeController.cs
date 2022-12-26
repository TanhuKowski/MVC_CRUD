using MVC_CRUD.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var model = db.Labours.ToList();
            return View(model);
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Labour labour)
        {
            db.Labours.Add(labour);
            db.SaveChanges();
            ViewBag.Message("Data inserted successfully!");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var delete = db.Labours.Find(id);
            if (delete == null)
            {

                return HttpNotFound();
            }
            db.Labours.Remove(delete);
            db.SaveChanges();
            return View();
        }
        public ActionResult Update(int id)
        {
            var model = db.Labours.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Create", model);
        }

    }
}