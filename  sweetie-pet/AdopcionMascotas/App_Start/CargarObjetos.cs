using AdopcionMascotas.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.App_Start
{
    public class CargarObjetos
    {
        public static void cargar (ApplicationDbContext ctx)
        {

            
            var fotos = new List<Foto>
            {
                new Foto{ ID = 1, Url="~/img/1/1 (1).PNG"},
                new Foto{ ID = 2, Url="~/img/1/1 (2).PNG"},
                new Foto{ ID = 3, Url="~/img/1/1 (3).PNG"},
                new Foto{ ID = 4, Url="~/img/2/2 (1).PNG"},
                new Foto{ ID = 5, Url="~/img/2/2 (2).PNG"},
                new Foto{ ID = 6, Url="~/img/2/2 (3).PNG"},
                new Foto{ ID = 7, Url="~/img/3/3 (1).PNG"},
                new Foto{ ID = 8, Url="~/img/3/3 (2).PNG"},
                new Foto{ ID = 9, Url="~/img/3/3 (3).PNG"},
                new Foto{ ID = 10, Url="~/img/3/3 (4).PNG"},
                new Foto{ ID = 11, Url="~/img/3/3 (5).PNG"},
                new Foto{ ID = 12, Url="~/img/4/4 (1).PNG"},
                new Foto{ ID = 13, Url="~/img/4/4 (2).PNG"},
                new Foto{ ID = 14, Url="~/img/4/4 (3).PNG"},
                new Foto{ ID = 15, Url="~/img/4/4 (4).PNG"},
                new Foto{ ID = 16, Url="~/img/4/4 (5).PNG"},
                new Foto{ ID = 17, Url="~/img/4/4 (6).PNG"},
                new Foto{ ID = 18, Url="~/img/5/5 (1).PNG"},
                new Foto{ ID = 19, Url="~/img/5/5 (2).PNG"},
                new Foto{ ID = 20, Url="~/img/5/5 (3).PNG"},
                new Foto{ ID = 21, Url="~/img/5/5 (4).PNG"},
                new Foto{ ID = 22, Url="~/img/5/5 (5).PNG"},
                new Foto{ ID = 23, Url="~/img/5/5 (6).PNG"},
                new Foto{ ID = 24, Url="~/img/6/6 (1).PNG"},
                new Foto{ ID = 25, Url="~/img/6/6 (2).PNG"},                
                new Foto{ ID = 26, Url="~/img/6/6 (3).PNG"},
                new Foto{ ID = 27, Url="~/img/6/6 (4).PNG"},
                new Foto{ ID = 28, Url="~/img/6/6 (5).PNG"},
                new Foto{ ID = 29, Url="~/img/7/7 (1).PNG"},
                new Foto{ ID = 30, Url="~/img/7/7 (2).PNG"},
                new Foto{ ID = 31, Url="~/img/7/7 (3).PNG"},
                new Foto{ ID = 32, Url="~/img/8/8 (1).PNG"},
                new Foto{ ID = 33, Url="~/img/8/8 (2).PNG"},
                new Foto{ ID = 34, Url="~/img/9/9 (1).PNG"},
                new Foto{ ID = 35, Url="~/img/9/9 (2).PNG"},
                new Foto{ ID = 36, Url="~/img/10/10 (1).PNG"},

            };

            fotos.ForEach(f => ctx.Fotoes.Add(f));
            ctx.SaveChanges();

            var fundaciones = new List<Fundación>
            {
                new Fundación{ Nombre = "Paraiso de la mascota", Dirección = "cll 122", Barrio = "Pance", Correo = "paraiso@hotmail.com", Ciudad = "Cali", Telefono = "2321", Contraseña = "098765"},
                new Fundación{ Nombre = "pets", Dirección = "carrera 50", Barrio = "Republica", Correo = "pets@hotmail.com", Ciudad = "Cali", Telefono = "234421", Contraseña = "098765"},
                new Fundación{ Nombre = "Animalia", Dirección = "cll 32", Barrio = "Morichal", Correo = "animalia@hotmail.com", Ciudad = "Bogotá", Telefono = "24", Contraseña = "098765"},
                new Fundación{ Nombre = "planet", Dirección = "cll 32", Barrio = "pizamos", Correo = "planet@hotmail.com", Ciudad = "Manizales", Telefono = "24", Contraseña = "098765"},

            };

            fundaciones.ForEach(f => ctx.Fundaciones.Add(f));
            ctx.SaveChanges();

            var mascotas = new List<Mascota>
            {
                new Mascota {Nombre = "Tomas", Color = "Blanco con manchas", Edad=2, Historia="Rescatado de la calle", Raza="Labrador", Sexo="Hembra", Tamaño="mediano", Tipo="Perro" },

                new Mascota {Nombre = "Shanelle", Color = "Cafe", Edad=8, Historia="Perdido", Raza="Pastor Aleman", Sexo="Hembra", Tamaño="grande", Tipo="Perro" },

                new Mascota {Nombre = "Chloe", Color = "cafe", Edad=2, Historia="Rescatado de la calle", Raza="Chiuhaha", Sexo="Hembra", Tamaño="pequeño", Tipo="Perro" },

                new Mascota {Nombre = "Nacho", Color = "negro", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Macho", Tamaño="pequeño", Tipo="Gato" },

                new Mascota {Nombre = "Sacha", Color = "blanco", Edad=9, Historia="Rescatado de la calle", Raza="golden", Sexo="Hembra", Tamaño="grande", Tipo="Perro" },
          
                new Mascota {Nombre = "Mona", Color = "amarillo", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Hembra", Tamaño="pequeño", Tipo="Gato" },
                
                new Mascota {Nombre = "Lucas", Color = "amarillo", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Macho", Tamaño="pequeño", Tipo="Gato" },
                
                new Mascota {Nombre = "Copito", Color = "amarillo", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Macho", Tamaño="pequeño", Tipo="Gato" },
                
                new Mascota {Nombre = "Lucho", Color = "blanco", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Macho", Tamaño="pequeño", Tipo="Perro" },
                
                new Mascota {Nombre = "Tobby", Color = "blanco", Edad=3, Historia="Rescatado de la calle", Raza="común", Sexo="Macho", Tamaño="pequeño", Tipo="Perro" },
            };
            mascotas.ForEach(s => ctx.Mascotas.Add(s));
            ctx.SaveChanges();


            mascotas[0].Fundación = fundaciones[0];
            mascotas[1].Fundación = fundaciones[0];
            mascotas[2].Fundación = fundaciones[0];
            mascotas[3].Fundación = fundaciones[2];
            mascotas[4].Fundación = fundaciones[3];
            mascotas[5].Fundación = fundaciones[2];
            mascotas[6].Fundación = fundaciones[1];
            mascotas[7].Fundación = fundaciones[1];
            mascotas[8].Fundación = fundaciones[1];
            mascotas[9].Fundación = fundaciones[3];
            ctx.SaveChanges();

            mascotas[0].Fotos.Add(fotos[0]);
            mascotas[0].Fotos.Add(fotos[1]);
            mascotas[0].Fotos.Add(fotos[2]);
            mascotas[1].Fotos.Add(fotos[3]);
            mascotas[1].Fotos.Add(fotos[4]);
            mascotas[1].Fotos.Add(fotos[5]);
            mascotas[2].Fotos.Add(fotos[6]);
            mascotas[2].Fotos.Add(fotos[7]);
            mascotas[2].Fotos.Add(fotos[8]);
            mascotas[2].Fotos.Add(fotos[9]);
            mascotas[2].Fotos.Add(fotos[10]);
            mascotas[3].Fotos.Add(fotos[11]);
            mascotas[3].Fotos.Add(fotos[12]);
            mascotas[3].Fotos.Add(fotos[13]);
            mascotas[3].Fotos.Add(fotos[14]);
            mascotas[3].Fotos.Add(fotos[15]);
            mascotas[3].Fotos.Add(fotos[16]);
            mascotas[4].Fotos.Add(fotos[17]);
            mascotas[4].Fotos.Add(fotos[18]);
            mascotas[4].Fotos.Add(fotos[19]);
            mascotas[4].Fotos.Add(fotos[20]);
            mascotas[4].Fotos.Add(fotos[21]);
            mascotas[4].Fotos.Add(fotos[22]);
            mascotas[5].Fotos.Add(fotos[23]);
            mascotas[5].Fotos.Add(fotos[24]);
            mascotas[5].Fotos.Add(fotos[25]);
            mascotas[5].Fotos.Add(fotos[26]);
            mascotas[5].Fotos.Add(fotos[27]);
            mascotas[6].Fotos.Add(fotos[28]);
            mascotas[6].Fotos.Add(fotos[29]);
            mascotas[6].Fotos.Add(fotos[30]);
            mascotas[7].Fotos.Add(fotos[31]);
            mascotas[7].Fotos.Add(fotos[32]);
            mascotas[8].Fotos.Add(fotos[33]);
            mascotas[8].Fotos.Add(fotos[34]);
            mascotas[9].Fotos.Add(fotos[35]);
            ctx.SaveChanges();
        }
        
    }
}