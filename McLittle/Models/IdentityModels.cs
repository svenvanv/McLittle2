﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace McLittle.Models
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
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<SubCategory> subcategory { get; set; }
        public DbSet<SubSubCategory> subsubCategory { get; set; }
<<<<<<< HEAD

        public System.Data.Entity.DbSet<McLittle.Models.Blog> Blogs { get; set; }
=======
        public DbSet<Discount> discount { get; set; }
>>>>>>> 91ad8adc401db282114544cfcf5ac1c98c9dc912
    }
}