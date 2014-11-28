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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AdopcionMascotas.Controllers
{
    
    public class FundacionesController : Controller
    {
        private ApplicationDbContext db;
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

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public FundacionesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Fundaciones
        public ActionResult Index(String ciudad, String nombre, Int32? id, Int32? MascotaID)
        {
            ViewBag.ciudades = new SelectList(db.Fundaciones.OrderBy(f => f.Ciudad).Select(f => f.Ciudad).Distinct());
            var modelo = new FundacionMascotaFoto();
            if (!String.IsNullOrEmpty(ciudad) && !String.IsNullOrEmpty(nombre))
            {
                modelo.Fundaciones = db.Fundaciones.Where(f => f.Ciudad.Equals(ciudad)).Where(f => f.Nombre.Equals(nombre));
            }
            else if (!String.IsNullOrEmpty(ciudad))
            {
                modelo.Fundaciones = db.Fundaciones.Where(f => f.Ciudad.Equals(ciudad)).Distinct().OrderBy(f => f.Nombre);
            }
            else if (!String.IsNullOrEmpty(nombre))
                modelo.Fundaciones = db.Fundaciones.Where(f => f.Nombre.Equals(nombre)).OrderBy(f => f.Nombre);
            else
                modelo.Fundaciones = db.Fundaciones.OrderBy(f => f.Nombre);

            if (id != null)
            {
                ViewBag.FundacionID = id;
                modelo.Mascotas = modelo.Fundaciones.Where(f => f.ID == id.Value).Single().Mascotas;
            }
            if (MascotaID != null)
            {
                ViewBag.MascotaID = MascotaID;
                modelo.Fotos = modelo.Mascotas.Where(m => m.ID == MascotaID).Single().Fotos;
            }
            return View(modelo);
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
                var usuario = new ApplicationUser { UserName = fundación.Correo, Email = fundación.Correo };
                var adminresult = UserManager.Create(usuario, fundación.Contraseña);
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(usuario.Id, "Fundacion");
                    if (result.Succeeded)
                    {
                        fundación.usuario = usuario;
                        db.Fundaciones.Add(fundación);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("no se le pudo asociar un rol al usuario", adminresult.Errors.First());
                        ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                        return View(fundación);
                    }
                }


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


                var usuario = new ApplicationUser { UserName = fundación.Correo, Email = fundación.Correo };
                var us = UserManager.FindByName(usuario.Email);
                bool ok = false;
                string er = "";
                if( us == null )
                {
                    var adminresult = UserManager.Create(usuario, fundación.Contraseña);
                    ok = adminresult.Succeeded;
                    if(!ok)
                    {
                        er = adminresult.Errors.First();
                    }                        
                }
                
                if (ok)
                {
                    var result = UserManager.AddToRole(usuario.Id, "Fundacion");
                    if (result.Succeeded)
                    {
                        fundación.usuario = usuario;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("no se le pudo asociar un rol al usuario", er);
                        return View(fundación);
                    }
                }
                else if(us!=null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("error", er);
                    return View(fundación);
                }
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
