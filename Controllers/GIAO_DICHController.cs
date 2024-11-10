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
    public class GIAO_DICHController : Controller
    {
        private ThuVienSach_K22CNT2_NguyenNgocVyEntities db = new ThuVienSach_K22CNT2_NguyenNgocVyEntities();

        // GET: GIAO_DICH
        public ActionResult Index()
        {
            var gIAO_DICH = db.GIAO_DICH.Include(g => g.KHACH_HANG).Include(g => g.SACH);
            return View(gIAO_DICH.ToList());
        }

        // GET: GIAO_DICH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAO_DICH gIAO_DICH = db.GIAO_DICH.Find(id);
            if (gIAO_DICH == null)
            {
                return HttpNotFound();
            }
            return View(gIAO_DICH);
        }

        // GET: GIAO_DICH/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "HoTen");
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            return View();
        }

        // POST: GIAO_DICH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGD,MaKH,MaSach,NgayMuon,NgayTraDuKien,NgayTraThucTe")] GIAO_DICH gIAO_DICH)
        {
            if (ModelState.IsValid)
            {
                db.GIAO_DICH.Add(gIAO_DICH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "HoTen", gIAO_DICH.MaKH);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", gIAO_DICH.MaSach);
            return View(gIAO_DICH);
        }

        // GET: GIAO_DICH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAO_DICH gIAO_DICH = db.GIAO_DICH.Find(id);
            if (gIAO_DICH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "HoTen", gIAO_DICH.MaKH);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", gIAO_DICH.MaSach);
            return View(gIAO_DICH);
        }

        // POST: GIAO_DICH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGD,MaKH,MaSach,NgayMuon,NgayTraDuKien,NgayTraThucTe")] GIAO_DICH gIAO_DICH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAO_DICH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "HoTen", gIAO_DICH.MaKH);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", gIAO_DICH.MaSach);
            return View(gIAO_DICH);
        }

        // GET: GIAO_DICH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAO_DICH gIAO_DICH = db.GIAO_DICH.Find(id);
            if (gIAO_DICH == null)
            {
                return HttpNotFound();
            }
            return View(gIAO_DICH);
        }

        // POST: GIAO_DICH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIAO_DICH gIAO_DICH = db.GIAO_DICH.Find(id);
            db.GIAO_DICH.Remove(gIAO_DICH);
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
