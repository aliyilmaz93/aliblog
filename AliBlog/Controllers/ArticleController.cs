using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AliBlog.Models;
using PagedList;
using PagedList.Mvc;

namespace AliBlog.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            return View(db.ArticleModels.OrderBy(x => x.ReleasedDate).ToPagedList(page, 10));
        }

        // GET: Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = db.ArticleModels.Find(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Subject,Content,ReleasedDate")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                db.ArticleModels.Add(articleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleModel);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = db.ArticleModels.Find(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Subject,Content,ReleasedDate")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articleModel);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = db.ArticleModels.Find(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleModel articleModel = db.ArticleModels.Find(id);
            db.ArticleModels.Remove(articleModel);
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
