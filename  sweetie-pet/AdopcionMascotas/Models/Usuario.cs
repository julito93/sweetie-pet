using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime Fecha_Nac { get; set; }

        public virtual PadreAdoptivo PadreAdoptivo { get; set; }
             
    }
}