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
    public class CHI_TIET_GIAO_DICHController : Controller
    {
        private ThuVienSach_K22CNT2_NguyenNgocVyEntities db = new ThuVienSach_K22CNT2_NguyenNgocVyEntities();

        // GET: CHI_TIET_GIAO_DICH
        public ActionResult Index()
        {
            var cHI_TIET_GIAO_DICH = db.CHI_TIET_GIAO_DICH.Include(c => c.SACH).Include(c => c.GIAO_DICH);
            return View(cHI_TIET_GIAO_DICH.ToList());
        }

        // GET: CHI_TIET_GIAO_DICH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH = db.CHI_TIET_GIAO_DICH.Find(id);
            if (cHI_TIET_GIAO_DICH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_GIAO_DICH);
        }

        // GET: CHI_TIET_GIAO_DICH/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            ViewBag.MaGD = new SelectList(db.GIAO_DICH, "MaGD", "MaGD");
            return View();
        }

        // POST: CHI_TIET_GIAO_DICH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTGD,MaGD,MaSach,SoLuong,GiaTien,TrangThai")] CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH)
        {
            if (ModelState.IsValid)
            {
                db.CHI_TIET_GIAO_DICH.Add(cHI_TIET_GIAO_DICH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", cHI_TIET_GIAO_DICH.MaSach);
            ViewBag.MaGD = new SelectList(db.GIAO_DICH, "MaGD", "MaGD", cHI_TIET_GIAO_DICH.MaGD);
            return View(cHI_TIET_GIAO_DICH);
        }

        // GET: CHI_TIET_GIAO_DICH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH = db.CHI_TIET_GIAO_DICH.Find(id);
            if (cHI_TIET_GIAO_DICH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", cHI_TIET_GIAO_DICH.MaSach);
            ViewBag.MaGD = new SelectList(db.GIAO_DICH, "MaGD", "MaGD", cHI_TIET_GIAO_DICH.MaGD);
            return View(cHI_TIET_GIAO_DICH);
        }

        // POST: CHI_TIET_GIAO_DICH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTGD,MaGD,MaSach,SoLuong,GiaTien,TrangThai")] CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHI_TIET_GIAO_DICH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", cHI_TIET_GIAO_DICH.MaSach);
            ViewBag.MaGD = new SelectList(db.GIAO_DICH, "MaGD", "MaGD", cHI_TIET_GIAO_DICH.MaGD);
            return View(cHI_TIET_GIAO_DICH);
        }

        // GET: CHI_TIET_GIAO_DICH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH = db.CHI_TIET_GIAO_DICH.Find(id);
            if (cHI_TIET_GIAO_DICH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_GIAO_DICH);
        }

        // POST: CHI_TIET_GIAO_DICH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHI_TIET_GIAO_DICH cHI_TIET_GIAO_DICH = db.CHI_TIET_GIAO_DICH.Find(id);
            db.CHI_TIET_GIAO_DICH.Remove(cHI_TIET_GIAO_DICH);
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
