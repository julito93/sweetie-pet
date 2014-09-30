using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class AnotacionesPadresAdoptivos
    {
        [Required(ErrorMessage = "¿Cuál es su cédula?")]
        [MaxLength(20)]
        [Display(Name = "Número de cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "¿Cuál es su nombre?")]
        [Display(Name = "Nombre :")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "¿Cuál es su dirección?")]
        [Display(Name = "Dirección :")]
        [MaxLength(20)]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "¿Cuál es su teléfono?")]
        [Display(Name = "Teléfono :")]
        [MaxLength(10)]
        public string Telefono { get; set; }

    }
    [MetadataType(typeof(AnotacionesPadresAdoptivos))]
    public partial class PadreAdoptivo { }
}