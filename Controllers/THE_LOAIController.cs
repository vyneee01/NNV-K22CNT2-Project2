using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThuVienSach_NguyenNgocVy.Models;

namespace ThuVienSach_NguyenNgocVy.Controllers
{
    public class THE_LOAIController : Controller
    {
        private ThuVienSach_K22CNT2_NguyenNgocVyEntities db = new ThuVienSach_K22CNT2_NguyenNgocVyEntities();

        // GET: THE_LOAI
        public ActionResult Index()
        {
            return View(db.THE_LOAI.ToList());
        }

        // GET: THE_LOAI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE_LOAI tHE_LOAI = db.THE_LOAI.Find(id);
            if (tHE_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHE_LOAI);
        }

        // GET: THE_LOAI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THE_LOAI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTheLoai,TenTheLoai")] THE_LOAI tHE_LOAI)
        {
            if (ModelState.IsValid)
            {
                db.THE_LOAI.Add(tHE_LOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHE_LOAI);
        }

        // GET: THE_LOAI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE_LOAI tHE_LOAI = db.THE_LOAI.Find(id);
            if (tHE_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHE_LOAI);
        }

        // POST: THE_LOAI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTheLoai,TenTheLoai")] THE_LOAI tHE_LOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHE_LOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHE_LOAI);
        }

        // GET: THE_LOAI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE_LOAI tHE_LOAI = db.THE_LOAI.Find(id);
            if (tHE_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHE_LOAI);
        }

        // POST: THE_LOAI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THE_LOAI tHE_LOAI = db.THE_LOAI.Find(id);
            db.THE_LOAI.Remove(tHE_LOAI);
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
