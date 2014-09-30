using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.Models
{
    public class AnotacionesMascota
    {
        [Required(ErrorMessage = "¿Cuál es su nombre?")]
        [MaxLength(20)]
        [Display(Name = "Nombre de la mascota:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "¿Cuál es su raza?")]
        [Display(Name = "Raza :")]
        [MaxLength(20)]
        public string Raza { get; set; }

        [Required(ErrorMessage = "¿Cuál es su color?")]
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

        [Display(Name = "Su historia :")]
        [MaxLength(20)]
        public string Historia { get; set; }
        
        [Required(ErrorMessage = "¿Cuál es su edad?")]
        [Display(Name = "Edad :")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "¿Es perro o gato?")]
        [Display(Name = "Tipo :")]
        [MaxLength(20)]
        public string Tipo { get; set; }
    }
    [MetadataType(typeof(AnotacionesMascota))]
    public partial class Mascota { }
}