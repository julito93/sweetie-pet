using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AdopcionMascotas.Models;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

      //  public DateTime Fecha_Nac { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AdopcionMascotas.Models.Fundación> Fundaciones { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.Mascota> Mascotas { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.Foto> Fotoes { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.PadreAdoptivo> PadreAdoptivoes { get; set; }

        public System.Data.Entity.DbSet<AdopcionMascotas.Models.SolicitudAdopcion> SolicitudAdopcions { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string nombre) : base(nombre) { }
        public string Descripción { get; set; }
    }
}