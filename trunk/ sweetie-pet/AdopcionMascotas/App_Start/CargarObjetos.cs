using AdopcionMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopcionMascotas.App_Start
{
    public class CargarObjetos
    {
        public static void cargar (Contexto ctx)
        {

            
            var fotos = new List<Foto>
            {
                new Foto{ ID = 1, Url="mascota1"},
                new Foto{ ID = 2, Url="mascota1"},
                new Foto{ ID = 3, Url="mascota1"},
                new Foto{ ID = 4, Url="mascota1"},
                new Foto{ ID = 5, Url="mascota1"},
                new Foto{ ID = 6, Url="mascota1"},
                new Foto{ ID = 7, Url="mascota1"},
            };

            fotos.ForEach(f => ctx.Fotoes.Add(f));
            ctx.SaveChanges();

            var fundaciones = new List<Fundación>
            {
                new Fundación{ Nombre = "Paraiso de la mascota", Dirección = "cll 122", Barrio = "Pance", Correo = "correo@hotmail.com", Ciudad = "Cali", Telefono = "2321", Contraseña = "fff"},
                new Fundación{ Nombre = "pets", Dirección = "carrera 50", Barrio = "Republica", Correo = "correo32@hotmail.com", Ciudad = "Cali", Telefono = "234421", Contraseña = "ddd"},
                new Fundación{ Nombre = "Animalia", Dirección = "cll 32", Barrio = "Morichal", Correo = "correo32@hotmail.com", Ciudad = "Bogotá", Telefono = "24", Contraseña = "rrr"},

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
            };
            mascotas.ForEach(s => ctx.Mascotas.Add(s));
            ctx.SaveChanges();


            mascotas[0].Fundación = fundaciones[0];
            mascotas[1].Fundación = fundaciones[0];
            mascotas[2].Fundación = fundaciones[1];
            mascotas[3].Fundación = fundaciones[2];
            mascotas[4].Fundación = fundaciones[2];
            ctx.SaveChanges();

            mascotas[0].Fotos.Add(fotos[0]);
            mascotas[0].Fotos.Add(fotos[1]);
            mascotas[0].Fotos.Add(fotos[2]);
            mascotas[1].Fotos.Add(fotos[3]);
            mascotas[2].Fotos.Add(fotos[4]);
            mascotas[3].Fotos.Add(fotos[5]);
            mascotas[4].Fotos.Add(fotos[6]);
            ctx.SaveChanges();
            

        }

    }
}