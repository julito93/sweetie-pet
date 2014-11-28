using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using IdentitySample.Models;
using System.Collections.Generic;
using AdopcionMascotas.Models;

namespace IdentitySample.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Foto> fotos = db.SolicitudAdopcions.Where(s => s.Estado.Equals("Aprobado")).Select(s => s.Mascota.Fotos.FirstOrDefault()).Include(s => s.Mascota).ToList();
            return View(fotos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
