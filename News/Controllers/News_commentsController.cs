using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News.Data;
using News.Models;

namespace News.Controllers
{
    public class News_commentsController : Controller
    {
        private News_commentContext db = new News_commentContext();

        // GET: News_comments
        public ActionResult Index()
        {
            var news_comments = db.News_comments.Include(n => n.News);
            return View(news_comments.ToList());
        }

        // GET: News_comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_comments news_comments = db.News_comments.Find(id);
            if (news_comments == null)
            {
                return HttpNotFound();
            }
            return View(news_comments);
        }

        // GET: News_comments/Create
        public ActionResult Create()
        {
            ViewBag.News_id = new SelectList(db.News, "News_id", "News_title");
            return View();
        }

        // POST: News_comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comment_id,Comment_name,Comment_email,Comment_date,News_id")] News_comments news_comments)
        {
            if (ModelState.IsValid)
            {
                db.News_comments.Add(news_comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.News_id = new SelectList(db.News, "News_id", "News_title", news_comments.News_id);
            return View(news_comments);
        }

        // GET: News_comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_comments news_comments = db.News_comments.Find(id);
            if (news_comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.News_id = new SelectList(db.News, "News_id", "News_title", news_comments.News_id);
            return View(news_comments);
        }

        // POST: News_comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comment_id,Comment_name,Comment_email,Comment_date,News_id")] News_comments news_comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.News_id = new SelectList(db.News, "News_id", "News_title", news_comments.News_id);
            return View(news_comments);
        }

        // GET: News_comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_comments news_comments = db.News_comments.Find(id);
            if (news_comments == null)
            {
                return HttpNotFound();
            }
            return View(news_comments);
        }

        // POST: News_comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_comments news_comments = db.News_comments.Find(id);
            db.News_comments.Remove(news_comments);
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
