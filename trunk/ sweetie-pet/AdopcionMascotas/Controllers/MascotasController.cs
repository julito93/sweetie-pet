using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdopcionMascotas.Models;
using PagedList;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace AdopcionMascotas.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private ApplicationDbContext db;
        private ApplicationUserManager manager;
        public MascotasController()
        {
            db = new ApplicationDbContext();
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }

        // GET: Mascotas
        public ActionResult Index(string ordena, int? pag)
        {
            ViewBag.Nombre = String.IsNullOrEmpty(ordena) ? "Nombre desc" : "";
            ViewBag.Raza = ordena == "Raza" ? "Raza desc" : "Raza";
            ViewBag.Color = ordena == "Color" ? "Color desc" : "Color";
            ViewBag.Tamaño = ordena == "Tamaño" ? "Tamaño desc" : "Tamaño";
            ViewBag.Edad = ordena == "Edad" ? "Edad desc" : "Edad";
            ViewBag.Sexo = ordena == "Sexo" ? "Sexo desc" : "Sexo";
            ViewBag.Tipo = ordena == "Tipo" ? "Tipo desc" : "Tipo";
            var usuario = manager.FindById(User.Identity.GetUserId());
            
            var roles= manager.GetRoles(usuario.Id);

            IEnumerable<Mascota> mascotas = new List<Mascota>();
            if (roles.Contains("Padre Adoptivo"))
            {
                mascotas = db.SolicitudAdopcions.Where(s => s.PadreAdoptivo.usuario.Id.Equals(usuario.Id) && s.Estado.Equals("Aprobado")).Select(s=>s.Mascota).ToList();
            }
            else if (roles.Contains("Fundacion"))
            {
                mascotas = db.Mascotas.Where(m => m.Fundación.Correo.Equals(usuario.Email)).ToList();
            }
            else if (roles.Contains("Admin"))
            {
                mascotas = db.Mascotas.ToList();
            }
                
            switch (ordena)
            {
                case "Nombre desc":
                    mascotas = mascotas.OrderByDescending(m => m.Nombre);
                    break;
                case "Raza desc":
                    mascotas = mascotas.OrderByDescending(m => m.Raza);
                    break;
                case "Color desc":
                    mascotas = mascotas.OrderByDescending(m => m.Color);
                    break;
                case "Tamaño desc":
                    mascotas = mascotas.OrderByDescending(m => m.Tamaño);
                    break;
                case "Edad desc":
                    mascotas = mascotas.OrderByDescending(m => m.Edad);
                    break;
                case "Tipo desc":
                    mascotas = mascotas.OrderByDescending(m => m.Tipo);
                    break;
                case "Sexo desc":
                    mascotas = mascotas.OrderByDescending(m => m.Sexo);
                    break;
                case "Raza":
                    mascotas = mascotas.OrderBy(m => m.Raza);
                    break;
                case "Color":
                    mascotas = mascotas.OrderBy(m => m.Color);
                    break;
                case "Tamaño":
                    mascotas = mascotas.OrderBy(m => m.Tamaño);
                    break;
                case "Edad":
                    mascotas = mascotas.OrderBy(m => m.Edad);
                    break;
                case "Tipo":
                    mascotas = mascotas.OrderBy(m => m.Tipo);
                    break;
                case "Sexo":
                    mascotas = mascotas.OrderBy(m => m.Sexo);
                    break;
                default:
                    mascotas = mascotas.OrderBy(m => m.Nombre);
                    break;
            }
            int tamañoPag = 3;
            int numPag = (pag ?? 1);
            return View(mascotas.ToPagedList(numPag, tamañoPag));
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascotas/Create
        [Authorize(Roles = "Fundacion")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Raza,Color,Tamaño,Sexo,Historia,Edad,Tipo")] Mascota mascota)
        {
            var usuario = manager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                mascota.Fundación = db.Fundaciones.Where(f => f.Correo.Equals(usuario.Email)).Single();
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Raza,Color,Tamaño,Sexo,Historia,Edad,Tipo")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
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
