﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CIT280_Capstone.Models
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

        public System.Data.Entity.DbSet<CIT280_Capstone.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<CIT280_Capstone.Models.Order> Orders { get; set; }

        public DbSet<CIT280_Capstone.Models.LineItem> LineItems { get; set; }

        public System.Data.Entity.DbSet<CIT280_Capstone.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<CIT280_Capstone.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<CIT280_Capstone.Models.MailingList> MailingLists { get; set; }
    }
}