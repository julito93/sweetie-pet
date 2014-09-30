using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class AnotacionesFundaciones
    {
        [Required(ErrorMessage = "¿Cuál es el nombre de la fundación?")]
        [Display(Name = "Nombre de la fundación: ")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "¿Cuál es el correo?")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo: ")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "¿Cuál es el teléfono?")]
        [Display(Name = "Teléfono :")]
        [MaxLength(10)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "¿Cuál es la ciudad?")]
        [Display(Name = "Ciudad :")]
        [MaxLength(30)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "¿Cuál es la dirección?")]
        [Display(Name = "Dirección :")]
        [MaxLength(30)]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "¿Cuál es el barrio?")]
        [Display(Name = "Barrio :")]
        [MaxLength(30)]
        public string Barrio { get; set; }
    
    }

    [MetadataType(typeof(AnotacionesFundaciones))]
    public partial class Fundación { }
}