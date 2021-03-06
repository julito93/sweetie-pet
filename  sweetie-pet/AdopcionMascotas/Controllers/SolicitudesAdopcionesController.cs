﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdopcionMascotas.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace AdopcionMascotas.Controllers
{
    [Authorize]
    public class SolicitudesAdopcionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "Fundacion")]
        public ActionResult Aprobar(Int32? SolicitudID)
        {
            if (SolicitudID != null)
            {
                SolicitudAdopcion solicitud = db.SolicitudAdopcions.Find(SolicitudID);
                solicitud.Estado = "Aprobado";
                db.Entry(solicitud);

                var user = UserManager.FindById(User.Identity.GetUserId());
                var solicitudes = db.SolicitudAdopcions.Where(s => s.Mascota.ID == solicitud.MascotaID && s.Mascota.Fundación.Correo.Equals(user.Email) && s.ID != solicitud.ID);

                foreach (SolicitudAdopcion s in solicitudes)
                {
                    s.Estado = "No aprobado";
                    db.Entry(s);
                }
                db.SaveChanges();
            }

            return RedirectToAction("IndexFundacion");
        }

        // GET: SolicitudesAdopciones
        [Authorize(Roles = "Padre Adoptivo")]
        public ActionResult Index(Int32? id)
        {
            SolicitudFotos modelo = new SolicitudFotos();
            var user = UserManager.FindById(User.Identity.GetUserId());
            modelo.Solicitudes = db.SolicitudAdopcions.Where(s => s.PadreAdoptivo.usuario.Email.Equals(user.Email)).Include(s => s.Mascota);

            if (id != null)
            {
                ViewBag.SolicitudID = id;
                modelo.Fotos = db.Fotoes.Where(f => f.Mascota.SolicitudesAdopcion.Where(s => s.ID == id).Count() > 0);
            }

            return View(modelo);
        }

        [Authorize(Roles = "Fundacion, Admin")]
        public ActionResult IndexFundacion()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (!UserManager.IsInRole(user.Id, "Admin"))
            {
                var solicitudes = db.SolicitudAdopcions.Where(s => s.Mascota.Fundación.Correo.Equals(user.Email));
                return View(solicitudes.ToList());
            }
            else
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
