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
using Microsoft.AspNet.Identity.Owin;

namespace AdopcionMascotas.Controllers
{
    [Authorize]
    public class PadresAdoptivosController : Controller
    {
        private ApplicationDbContext db;
        private ApplicationUserManager manager;

        public PadresAdoptivosController()
        {
            db = new ApplicationDbContext();
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
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

        // GET: PadresAdoptivos
        [Authorize(Roles = "Fundacion")]
        public ActionResult Index()
        {
            var user = manager.FindById(User.Identity.GetUserId());
            var padresAdoptivos = db.SolicitudAdopcions.Where(s => s.Mascota.Fundación.Correo.Equals(user.Email)).Select(s=>s.PadreAdoptivo).Distinct();
            return View(padresAdoptivos);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Usuario, Padre Adoptivo")]
        public ActionResult Create(Int32? MascotaID)
        {
            var user = manager.FindById(User.Identity.GetUserId());
            var role = RoleManager.FindByName("Padre Adoptivo");
            IList<string> rolesForUser = UserManager.GetRoles(user.Id);
            if (rolesForUser.Contains(role.Name))
            {
                var padre = db.PadreAdoptivoes.Where(p=>p.usuario.Id.Equals(user.Id) ).Single();
                var fecha = DateTime.Today.Date.ToString();
                var estado = "Sin Aprobar";
                SolicitudAdopcion s = new SolicitudAdopcion()
                {
                    PadreAdoptivo = padre,
                    Estado = estado,
                    PadreAdoptivo_Cedula = padre.Cedula,
                    Fecha_Adop = fecha
                };
                var mas = db.Mascotas.Where(m => m.ID == MascotaID).Single();
                s.Mascota = mas;
                db.SolicitudAdopcions.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index", "SolicitudesAdopciones");
            }
            return View();
        }

        // POST: PadresAdoptivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Cedula,Dirección,Barrio,Telefono")] PadreAdoptivo padreAdoptivo, Int32? MascotaID)
        {
            if (ModelState.IsValid)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                padreAdoptivo.usuario = user;
                db.PadreAdoptivoes.Add(padreAdoptivo);

                var result = UserManager.AddToRole(user.Id, "Padre Adoptivo");

                var fecha = DateTime.Today.Date.ToString();
                var estado = "Sin Aprobar";
                SolicitudAdopcion s = new SolicitudAdopcion()
                {
                    PadreAdoptivo = padreAdoptivo,
                    Estado = estado,
                    PadreAdoptivo_Cedula = padreAdoptivo.Cedula,
                    Fecha_Adop = fecha
                };
                var mas = db.Mascotas.Where(m => m.ID == MascotaID).Single();
                s.Mascota=mas;
                db.SolicitudAdopcions.Add(s);
                db.SaveChanges();

                return RedirectToAction("Index", "SolicitudesAdopciones");
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
