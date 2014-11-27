using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class SolicitudAdopcion
    {
        [Key]
        public int ID { get; set; }
        public string PadreAdoptivo_Cedula { get; set; }
        public string Fecha_Adop { get; set; }
        public string Estado { get; set; }

        public int MascotaID { get; set; }

        public virtual PadreAdoptivo PadreAdoptivo {get; set;}
       
        public virtual Mascota Mascota { get; set; }

        public string NombreMascota
        {
            get
            {
                return Mascota.Nombre;
            }
        }
        
    }
}