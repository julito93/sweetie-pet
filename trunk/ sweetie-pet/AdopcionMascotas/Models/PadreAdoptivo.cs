using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class PadreAdoptivo
    {
        public int ID { get; set; }
        public string Nombre {get; set;}
        public string Cedula { get; set; }
        public string Dirección { get; set; }
        public string Barrio { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<SolicitudAdopcion> Adopciones { get; set; }
        
        public PadreAdoptivo()
        {
            this.Adopciones = new HashSet<SolicitudAdopcion>();
        }

    }
}