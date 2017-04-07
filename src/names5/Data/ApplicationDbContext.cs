using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using names5.Models;

namespace names5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //===============================================================
        //Fields.
        //===============================================================

        //===============================================================
        //Properties.
        //===============================================================
        public DbSet<Name> Names { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<NameAddress> NameAddresses { get; set; }
        
        //===============================================================
        //Constructor().
        //===============================================================
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //===============================================================
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //Create the unique primary key for the join table, Name Address.
            builder.Entity<NameAddress>().HasKey(x => new { x.NameId, x.AddressId });

        }
        //===============================================================

    }
}
