using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UserAuthentication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public string Picture { get; set; }
    
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string FullAddress { get; set; }
     
        public string State { get; set; }
        public string subscription { get; set; }
        public string wallet { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UserAuthentication_.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<UserAuthentication.Models.Bid> Bids { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.ProjectDocument> ProjectDocument { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Subscription> Subscription { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Plans> Plans { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Contact> Contact { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.DemoPayment> DemoPayment { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Category> Category { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.SubCategory> SubCategory { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Products> Products { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Cart> Cart { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Order> Order { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.OrderDetails> OrderDetail { get; set; }
        public System.Data.Entity.DbSet<UserAuthentication.Models.Address> Address { get; set; }




    }
}