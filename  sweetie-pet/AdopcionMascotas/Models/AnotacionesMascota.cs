using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class AnotacionesMascota
    {
        [Required(ErrorMessage = "Digite el nombre de la mascota")]
        [MaxLength(20)]
        [Display(Name = "Nombre :")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Digite la raza de la mascota")]
        [Display(Name = "Raza :")]
        [MaxLength(20)]
        public string Raza { get; set; }

        [Required(ErrorMessage = "Digite el color de la mascota")]
        [Display(Name = "Color :")]
        [MaxLength(20)]
        public string Color { get; set; }

        [Required(ErrorMessage = "¿Cuál es su tamaño?")]
        [Display(Name = "Tamaño :")]
        [MaxLength(5)]
        public string Tamaño { get; set; }

        [Required(ErrorMessage = "¿Es hembra o macho?")]
        [Display(Name = "Sexo :")]
        [MaxLength(20)]
        public string Sexo { get; set; }

        [Display(Name = "Cuentanos su historia :")]
        [MaxLength(20)]
        public string Historia { get; set; }
        
        [Required(ErrorMessage = "¿Cuál es la edad de la mascota?")]
        [Display(Name = "Edad :")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "¡Es perro o gato?")]
        [Display(Name = "Tipo :")]
        [MaxLength(20)]
        public string Tipo { get; set; }
    }
    [MetadataType(typeof(AnotacionesMascota))]
    public partial class Mascota { }
}