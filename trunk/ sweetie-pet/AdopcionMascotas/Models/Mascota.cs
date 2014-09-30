using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public partial class Mascota
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Tamaño { get; set; }
        public string Sexo { get; set; }
        public string Historia { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }

        public virtual Fundación Fundación {get; set;}
        public virtual SolicitudAdopcion Adopcion { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }

        public Mascota ()
        {
            this.Fotos = new HashSet<Foto>();
        }
    }
}