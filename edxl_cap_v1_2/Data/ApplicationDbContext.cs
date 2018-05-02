using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models.ContentViewModels;
using Microsoft.AspNetCore.Identity;

namespace edxl_cap_v1_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<EdxlCapMessageViewModel> EdxlCapMessageViewModel { get; set;  }

        public virtual DbSet<Person> Persons { get; set; }

        public DbSet<Alert> Alert { get; set; }

        public DbSet<Area> Area { get; set; }

        public DbSet<DataCategory> DataCategory { get; set; }

        public DbSet<Element> Element { get; set; }

        public DbSet<Info> Info { get; set; }

        public DbSet<Resource> Resource { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Alert>().ToTable("Alert");
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<DataCategory>().ToTable("DataCategory");
            modelBuilder.Entity<Element>().ToTable("Element");
            modelBuilder.Entity<Info>().ToTable("Info");
            modelBuilder.Entity<Resource>().ToTable("Resource");
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUser<string>>(entity => entity.Property(m => m.Id).HasMaxLength(200));
            modelBuilder.Entity<IdentityRole<string>>(entity => entity.Property(m => m.Id).HasMaxLength(200));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(200));
        }
    }
}
