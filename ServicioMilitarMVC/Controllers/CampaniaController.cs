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
    public class CampaniaController : Controller
    {
        private servicioMilitarEntities db = new servicioMilitarEntities();

        public ActionResult Index()
        {
            return View(db.CAMPANIA.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPANIA cAMPANIA = db.CAMPANIA.Find(id);
            if (cAMPANIA == null)
            {
                return HttpNotFound();
            }
            return View(cAMPANIA);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroCampania,actividad")] CAMPANIA cAMPANIA)
        {
            if (ModelState.IsValid)
            {
                db.CAMPANIA.Add(cAMPANIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAMPANIA);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPANIA cAMPANIA = db.CAMPANIA.Find(id);
            if (cAMPANIA == null)
            {
                return HttpNotFound();
            }
            return View(cAMPANIA);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroCampania,actividad")] CAMPANIA cAMPANIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPANIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAMPANIA);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPANIA cAMPANIA = db.CAMPANIA.Find(id);
            if (cAMPANIA == null)
            {
                return HttpNotFound();
            }
            return View(cAMPANIA);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAMPANIA cAMPANIA = db.CAMPANIA.Find(id);
            db.CAMPANIA.Remove(cAMPANIA);
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
