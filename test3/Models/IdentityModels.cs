using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using test3.Data;

namespace test3.Models
{
   
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public class Empolyee
        //{
        //    [Key]
        //    public string Id { get; set; }

        //    [ForeignKey("UserId")]
        //    public virtual ApplicationUser ApplicationUser { get; set; }
        //}


        //public virtual Employee Employee { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        //public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // one-to-zero or one relationship between ApplicationUser and Customer
        //    // UserId column in Customers table will be foreign key
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasOptional(m => m.Employee)
        //        .WithRequired(m => m.ApplicationUser)
        //        .Map(p => p.MapKey("UserId"));
        //}


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}