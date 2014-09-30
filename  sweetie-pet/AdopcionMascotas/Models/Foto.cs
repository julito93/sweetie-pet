using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class Foto
    {
        public int ID { get; set; }
        public string Url { get; set; }

        public Mascota Mascota { get; set; }
    }
}