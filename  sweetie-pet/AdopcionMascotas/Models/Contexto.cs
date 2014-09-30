using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AdopcionMascotas.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Fundación> Fundaciones { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.Mascota> Mascotas { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.Foto> Fotoes { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.PadreAdoptivo> PadreAdoptivoes { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.SolicitudAdopcion> SolicitudAdopcions { get; set; }
    }
}