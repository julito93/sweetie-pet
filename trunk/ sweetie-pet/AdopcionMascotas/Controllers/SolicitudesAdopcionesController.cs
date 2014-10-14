using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdopcionMascotas.Models;
using IdentitySample.Models;

namespace AdopcionMascotas.Controllers
{
    public class SolicitudesAdopcionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitudesAdopciones
        public ActionResult Index()
        {
            return View(db.SolicitudAdopcions.ToList());
        }

        // GET: SolicitudesAdopciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudAdopcion solicitudAdopcion = db.SolicitudAdopcions.Find(id);
            if (solicitudAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudAdopcion);
        }

        // GET: SolicitudesAdopciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudesAdopciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PadreAdoptivo_Cedula,Fecha_Adop,Estado")] SolicitudAdopcion solicitudAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudAdopcions.Add(solicitudAdopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitudAdopcion);
        }

        // GET: SolicitudesAdopciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudAdopcion solicitudAdopcion = db.SolicitudAdopcions.Find(id);
            if (solicitudAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudAdopcion);
        }

        // POST: SolicitudesAdopciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PadreAdoptivo_Cedula,Fecha_Adop,Estado")] SolicitudAdopcion solicitudAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudAdopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitudAdopcion);
        }

        // GET: SolicitudesAdopciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudAdopcion solicitudAdopcion = db.SolicitudAdopcions.Find(id);
            if (solicitudAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudAdopcion);
        }

        // POST: SolicitudesAdopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudAdopcion solicitudAdopcion = db.SolicitudAdopcions.Find(id);
            db.SolicitudAdopcions.Remove(solicitudAdopcion);
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
