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
    public class CPUController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.CPUs.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                db.CPUs.Add(cpu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cpu);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cpu = db.CPUs.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cpu);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cpu = db.CPUs.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPU cpu = db.CPUs.Find(id);
            db.CPUs.Remove(cpu);
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
