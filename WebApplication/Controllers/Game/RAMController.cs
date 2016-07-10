using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.GameModels;
using WebApplication.Models;

namespace WebApplication.Controllers.Game
{
    public class RAMController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        public ActionResult Index()
        {
            return View(db.RAMs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title")] RAM ram)
        {
            if (ModelState.IsValid)
            {
                db.RAMs.Add(ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ram);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM ram = db.RAMs.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title")] RAM ram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ram);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM ram = db.RAMs.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAM ram = db.RAMs.Find(id);
            db.RAMs.Remove(ram);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
