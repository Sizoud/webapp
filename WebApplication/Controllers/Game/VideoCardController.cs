using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models.GameModels;
using WebApplication.Models;

namespace WebApplication.Controllers.Game
{
    public class VideoCardController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.VideoCards.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title")] VideoCard videocard)
        {
            if (ModelState.IsValid)
            {
                db.VideoCards.Add(videocard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videocard);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoCard videocard = db.VideoCards.Find(id);
            if (videocard == null)
            {
                return HttpNotFound();
            }
            return View(videocard);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title")] VideoCard videocard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videocard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videocard);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoCard videocard = db.VideoCards.Find(id);
            if (videocard == null)
            {
                return HttpNotFound();
            }
            return View(videocard);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoCard videocard = db.VideoCards.Find(id);
            db.VideoCards.Remove(videocard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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
