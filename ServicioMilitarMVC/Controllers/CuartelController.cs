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
    public class CuartelController : Controller
    {
        private servicioMilitarEntities db = new servicioMilitarEntities();

        public ActionResult Index()
        {
            return View(db.CUARTEL.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUARTEL cUARTEL = db.CUARTEL.Find(id);
            if (cUARTEL == null)
            {
                return HttpNotFound();
            }
            return View(cUARTEL);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoCuartel,nombre,ubicacion")] CUARTEL cUARTEL)
        {
            if (ModelState.IsValid)
            {
                db.CUARTEL.Add(cUARTEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUARTEL);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUARTEL cUARTEL = db.CUARTEL.Find(id);
            if (cUARTEL == null)
            {
                return HttpNotFound();
            }
            return View(cUARTEL);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoCuartel,nombre,ubicacion")] CUARTEL cUARTEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUARTEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUARTEL);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUARTEL cUARTEL = db.CUARTEL.Find(id);
            if (cUARTEL == null)
            {
                return HttpNotFound();
            }
            return View(cUARTEL);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUARTEL cUARTEL = db.CUARTEL.Find(id);
            db.CUARTEL.Remove(cUARTEL);
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
