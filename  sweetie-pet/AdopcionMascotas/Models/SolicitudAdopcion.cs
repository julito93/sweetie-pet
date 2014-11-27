using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class SolicitudAdopcion
    {
        public int ID { get; set; }
        public string PadreAdoptivo_Cedula { get; set; }
        public string Fecha_Adop { get; set; }
        public string Estado { get; set; }

        public virtual PadreAdoptivo PadreAdoptivo {get; set;}
        public virtual ICollection<Mascota> Mascotas { get; set; }

        public SolicitudAdopcion()
        {
            this.Mascotas = new HashSet<Mascota>();
        }
        
    }
}