using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Ajax.Utilities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GameController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard).ToList();
            games.Reverse();
            return View(games);
        }

        public ActionResult Novelty()
        {
            var games = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard).Where(x => x.Date.Substring(6).Equals("2016")).ToList();
            games.Reverse();
            return View("Index", games);
        }
        public ActionResult Discounts()
        {
            var games = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard).Where(x => x.Discount > 0).ToList();
            games.Reverse();
            return View("Index", games);
        }
        public ActionResult Genre(int id)
        {
            var games = db.Games.Include(g => g.CPU).Include(g => g.DirectX).Include(g => g.Genre).Include(g => g.OS).Include(g => g.RAM).Include(g => g.VideoCard).Where(x => x.GenreId == id).ToList();
            games.Reverse();
            return View("Index", games);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Publisher,GenreId,Date,Price,Discount,Img,Description,OSId,CPUId,RAMId,VideoCardId,DirectXId,HDD")] Models.Game game, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                game.Img = uploadImage == null ? game.Img.IfNullOrWhiteSpace("https://new.vk.com/images/camera_200.png") : UploadPic(uploadImage);
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
        private string UploadPic(HttpPostedFileBase uploadImage)
        {
            Models.Game content;
            ImageUploadResult uploadResult = null;
            Account account = new Account("celt", "478563425168974", "55ha3Kh1_40puuRq4ZoNKQfUeBk");
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(User.Identity.Name, uploadImage.InputStream),
                Transformation = new Transformation().Crop("limit").Width(800).Height(800)
            };

            uploadResult = cloudinary.Upload(uploadParams);
            if (uploadResult.Error != null)
            {
                return "https://new.vk.com/images/camera_200.png";
            }

            return uploadResult.Uri.AbsoluteUri;
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
        public ActionResult Edit([Bind(Include = "Id,Title,Publisher,GenreId,Date,Price,Discount,Img,Description,OSId,CPUId,RAMId,VideoCardId,DirectXId,HDD")] Models.Game game, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                game.Img = uploadImage == null ? game.Img.IfNullOrWhiteSpace("https://new.vk.com/images/camera_200.png") : UploadPic(uploadImage);
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
