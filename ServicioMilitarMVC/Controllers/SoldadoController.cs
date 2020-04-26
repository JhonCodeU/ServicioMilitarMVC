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
    public class SoldadoController : Controller
    {
        private servicioMilitarEntities db = new servicioMilitarEntities();

        public ActionResult Index()
        {
            var sOLDADO = db.SOLDADO.Include(s => s.CAMPANIA).Include(s => s.CUARTEL).Include(s => s.CUERPO);
            return View(sOLDADO.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLDADO sOLDADO = db.SOLDADO.Find(id);
            if (sOLDADO == null)
            {
                return HttpNotFound();
            }
            return View(sOLDADO);
        }

        public ActionResult Create()
        {
            ViewBag.numeroCampania = new SelectList(db.CAMPANIA, "numeroCampania", "actividad");
            ViewBag.codigoCuartel = new SelectList(db.CUARTEL, "codigoCuartel", "nombre");
            ViewBag.codigocuerpo = new SelectList(db.CUERPO, "codigocuerpo", "denominacion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoSoldado,nombre,apellido,grado,codigocuerpo,numeroCampania,codigoCuartel")] SOLDADO sOLDADO)
        {
            if (ModelState.IsValid)
            {
                db.SOLDADO.Add(sOLDADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numeroCampania = new SelectList(db.CAMPANIA, "numeroCampania", "actividad", sOLDADO.numeroCampania);
            ViewBag.codigoCuartel = new SelectList(db.CUARTEL, "codigoCuartel", "nombre", sOLDADO.codigoCuartel);
            ViewBag.codigocuerpo = new SelectList(db.CUERPO, "codigocuerpo", "denominacion", sOLDADO.codigocuerpo);
            return View(sOLDADO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLDADO sOLDADO = db.SOLDADO.Find(id);
            if (sOLDADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.numeroCampania = new SelectList(db.CAMPANIA, "numeroCampania", "actividad", sOLDADO.numeroCampania);
            ViewBag.codigoCuartel = new SelectList(db.CUARTEL, "codigoCuartel", "nombre", sOLDADO.codigoCuartel);
            ViewBag.codigocuerpo = new SelectList(db.CUERPO, "codigocuerpo", "denominacion", sOLDADO.codigocuerpo);
            return View(sOLDADO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoSoldado,nombre,apellido,grado,codigocuerpo,numeroCampania,codigoCuartel")] SOLDADO sOLDADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLDADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numeroCampania = new SelectList(db.CAMPANIA, "numeroCampania", "actividad", sOLDADO.numeroCampania);
            ViewBag.codigoCuartel = new SelectList(db.CUARTEL, "codigoCuartel", "nombre", sOLDADO.codigoCuartel);
            ViewBag.codigocuerpo = new SelectList(db.CUERPO, "codigocuerpo", "denominacion", sOLDADO.codigocuerpo);
            return View(sOLDADO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLDADO sOLDADO = db.SOLDADO.Find(id);
            if (sOLDADO == null)
            {
                return HttpNotFound();
            }
            return View(sOLDADO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLDADO sOLDADO = db.SOLDADO.Find(id);
            db.SOLDADO.Remove(sOLDADO);
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
