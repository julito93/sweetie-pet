using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Controllers
{
    public class FundacionesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fundaciones
        public ActionResult Index()
        {
            return View(db.Fundaciones.ToList());
        }

        // GET: Fundaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fundación fundación = db.Fundaciones.Find(id);
            if (fundación == null)
            {
                return HttpNotFound();
            }
            return View(fundación);
        }

        // GET: Fundaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fundaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Dirección,Ciudad,Barrio,Correo,Contraseña")] Fundación fundación)
        {
            if (ModelState.IsValid)
            {
                db.Fundaciones.Add(fundación);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fundación);
        }

        // GET: Fundaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fundación fundación = db.Fundaciones.Find(id);
            if (fundación == null)
            {
                return HttpNotFound();
            }
            return View(fundación);
        }

        // POST: Fundaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Dirección,Ciudad,Barrio,Correo,Contraseña")] Fundación fundación)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fundación).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fundación);
        }

        // GET: Fundaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fundación fundación = db.Fundaciones.Find(id);
            if (fundación == null)
            {
                return HttpNotFound();
            }
            return View(fundación);
        }

        // POST: Fundaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fundación fundación = db.Fundaciones.Find(id);
            db.Fundaciones.Remove(fundación);
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
