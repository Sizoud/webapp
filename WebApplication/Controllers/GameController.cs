using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GameController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard);
            return View(games.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Game game = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard).SingleOrDefault(x => x.Id == id); ;

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult Create()
        {
            ViewBag.CPUId = new SelectList(db.CPUs, "Id", "Title");
            ViewBag.DirectXId = new SelectList(db.DirectXes, "Id", "Title");
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title");
            ViewBag.OSId = new SelectList(db.OS, "Id", "Title");
            ViewBag.RAMId = new SelectList(db.RAMs, "Id", "Title");
            ViewBag.VideoCardId = new SelectList(db.VideoCards, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Publisher,GenreId,Date,Price,Discount,Img,Description,OSId,CPUId,RAMId,VideoCardId,DirectXId,HDD")] Models.Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPUId = new SelectList(db.CPUs, "Id", "Title", game.CPUId);
            ViewBag.DirectXId = new SelectList(db.DirectXes, "Id", "Title", game.DirectXId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", game.GenreId);
            ViewBag.OSId = new SelectList(db.OS, "Id", "Title", game.OSId);
            ViewBag.RAMId = new SelectList(db.RAMs, "Id", "Title", game.RAMId);
            ViewBag.VideoCardId = new SelectList(db.VideoCards, "Id", "Title", game.VideoCardId);
            return View(game);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPUId = new SelectList(db.CPUs, "Id", "Title", game.CPUId);
            ViewBag.DirectXId = new SelectList(db.DirectXes, "Id", "Title", game.DirectXId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", game.GenreId);
            ViewBag.OSId = new SelectList(db.OS, "Id", "Title", game.OSId);
            ViewBag.RAMId = new SelectList(db.RAMs, "Id", "Title", game.RAMId);
            ViewBag.VideoCardId = new SelectList(db.VideoCards, "Id", "Title", game.VideoCardId);
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Publisher,GenreId,Date,Price,Discount,Img,Description,OSId,CPUId,RAMId,VideoCardId,DirectXId,HDD")] Models.Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPUId = new SelectList(db.CPUs, "Id", "Title", game.CPUId);
            ViewBag.DirectXId = new SelectList(db.DirectXes, "Id", "Title", game.DirectXId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", game.GenreId);
            ViewBag.OSId = new SelectList(db.OS, "Id", "Title", game.OSId);
            ViewBag.RAMId = new SelectList(db.RAMs, "Id", "Title", game.RAMId);
            ViewBag.VideoCardId = new SelectList(db.VideoCards, "Id", "Title", game.VideoCardId);
            return View(game);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
