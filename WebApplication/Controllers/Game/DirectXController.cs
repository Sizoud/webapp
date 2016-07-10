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
    public class DirectXController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        public ActionResult Index()
        {
            return View(db.DirectXes.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title")] DirectX directx)
        {
            if (ModelState.IsValid)
            {
                db.DirectXes.Add(directx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directx);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectX directx = db.DirectXes.Find(id);
            if (directx == null)
            {
                return HttpNotFound();
            }
            return View(directx);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title")] DirectX directx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directx);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectX directx = db.DirectXes.Find(id);
            if (directx == null)
            {
                return HttpNotFound();
            }
            return View(directx);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectX directx = db.DirectXes.Find(id);
            db.DirectXes.Remove(directx);
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
