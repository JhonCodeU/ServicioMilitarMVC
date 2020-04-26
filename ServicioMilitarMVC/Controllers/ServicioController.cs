using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServicioMilitarMVC.Models;

namespace ServicioMilitarMVC.Controllers
{
    public class ServicioController : Controller
    {
        private servicioMilitarEntities db = new servicioMilitarEntities();

        public ActionResult Index()
        {
            var sERVICIO = db.SERVICIO.Include(s => s.SOLDADO);
            return View(sERVICIO.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        public ActionResult Create()
        {
            ViewBag.codigoSoldado = new SelectList(db.SOLDADO, "codigoSoldado", "nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroServicio,descripcion,codigoSoldado")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIO.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoSoldado = new SelectList(db.SOLDADO, "codigoSoldado", "nombre", sERVICIO.codigoSoldado);
            return View(sERVICIO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoSoldado = new SelectList(db.SOLDADO, "codigoSoldado", "nombre", sERVICIO.codigoSoldado);
            return View(sERVICIO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroServicio,descripcion,codigoSoldado")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoSoldado = new SelectList(db.SOLDADO, "codigoSoldado", "nombre", sERVICIO.codigoSoldado);
            return View(sERVICIO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            db.SERVICIO.Remove(sERVICIO);
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
