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
    public class CuerpoController : Controller
    {
        private servicioMilitarEntities db = new servicioMilitarEntities();

        public ActionResult Index()
        {
            return View(db.CUERPO.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUERPO cUERPO = db.CUERPO.Find(id);
            if (cUERPO == null)
            {
                return HttpNotFound();
            }
            return View(cUERPO);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigocuerpo,denominacion")] CUERPO cUERPO)
        {
            if (ModelState.IsValid)
            {
                db.CUERPO.Add(cUERPO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUERPO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUERPO cUERPO = db.CUERPO.Find(id);
            if (cUERPO == null)
            {
                return HttpNotFound();
            }
            return View(cUERPO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigocuerpo,denominacion")] CUERPO cUERPO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUERPO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUERPO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUERPO cUERPO = db.CUERPO.Find(id);
            if (cUERPO == null)
            {
                return HttpNotFound();
            }
            return View(cUERPO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUERPO cUERPO = db.CUERPO.Find(id);
            db.CUERPO.Remove(cUERPO);
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
