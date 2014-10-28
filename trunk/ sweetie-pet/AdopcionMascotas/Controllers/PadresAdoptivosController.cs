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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdopcionMascotas.Controllers
{
    [Authorize]
    public class PadresAdoptivosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // GET: PadresAdoptivos
        public ActionResult Index()
        {
            var padresAdoptivos = db.PadreAdoptivoes.ToList();
            return View(padresAdoptivos);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult TodosLosPadresAdoptivos()
        {
            return View(db.PadreAdoptivoes.ToList());
        }

        // GET: PadresAdoptivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadreAdoptivo padreAdoptivo = db.PadreAdoptivoes.Find(id);
            if (padreAdoptivo == null)
            {
                return HttpNotFound();
            }
            return View(padreAdoptivo);
        }

        // GET: PadresAdoptivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PadresAdoptivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Cedula,Dirección,Barrio,Telefono")] PadreAdoptivo padreAdoptivo)
        {
            if (ModelState.IsValid)
            {
                db.PadreAdoptivoes.Add(padreAdoptivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(padreAdoptivo);
        }

        // GET: PadresAdoptivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadreAdoptivo padreAdoptivo = db.PadreAdoptivoes.Find(id);
            if (padreAdoptivo == null)
            {
                return HttpNotFound();
            }
            return View(padreAdoptivo);
        }

        // POST: PadresAdoptivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Cedula,Dirección,Barrio,Telefono")] PadreAdoptivo padreAdoptivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padreAdoptivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(padreAdoptivo);
        }

        // GET: PadresAdoptivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadreAdoptivo padreAdoptivo = db.PadreAdoptivoes.Find(id);
            if (padreAdoptivo == null)
            {
                return HttpNotFound();
            }
            return View(padreAdoptivo);
        }

        // POST: PadresAdoptivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PadreAdoptivo padreAdoptivo = db.PadreAdoptivoes.Find(id);
            db.PadreAdoptivoes.Remove(padreAdoptivo);
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
