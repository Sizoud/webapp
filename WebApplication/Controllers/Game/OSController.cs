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
    public class OSController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        public ActionResult Index()
        {
            return View(db.OS.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title")] OS os)
        {
            if (ModelState.IsValid)
            {
                db.OS.Add(os);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(os);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS os = db.OS.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title")] OS os)
        {
            if (ModelState.IsValid)
            {
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(os);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS os = db.OS.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OS os = db.OS.Find(id);
            db.OS.Remove(os);
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
