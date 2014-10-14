using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public partial class Fundación
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Mascota> Mascotas { get; set; }
        public virtual UsuarioFundacion Usuario { get; set; }

        public Fundación ()
        {
            this.Mascotas = new HashSet<Mascota>();
        }
    }
}