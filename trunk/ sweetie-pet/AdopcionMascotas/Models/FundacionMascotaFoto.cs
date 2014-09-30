using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class FundacionMascotaFoto
    {
        public IEnumerable<Fundación> Fundaciones { get; set; }

        public IEnumerable<Mascota> Mascotas { get; set; }

        public IEnumerable<Foto> Fotos { get; set; }
    }
}