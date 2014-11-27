using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class SolicitudFotos
    {
        public IEnumerable<SolicitudAdopcion> Solicitudes { get; set; }
        public IEnumerable<Foto> Fotos { get; set; }
    }
}