using Padarogga.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Data
{
    public class PadaroggaContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public PadaroggaContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {


        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Waypoint> Waypoints { get; set; }

        public DbSet<CustomerRating> Ratings { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Favorites> Favorites { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //CustomerRating
            modelBuilder.Entity<CustomerRating>()
                .HasKey(r => new { r.CustomerId, r.RouteId });

            modelBuilder.Entity<CustomerRating>()
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.Ratings)
                    .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<CustomerRating>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Ratings)
                   .HasForeignKey(r => r.RouteId);

            //Comment
            modelBuilder.Entity<Comment>()
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.Comments)
                    .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Comment>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Comments)
                  .HasForeignKey(r => r.RouteId);
            //Favorites
            modelBuilder.Entity<Favorites>()
              .HasKey(r => new { r.CustomerId, r.RouteId });

            modelBuilder.Entity<Favorites>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.Favorites)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Favorites>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Favorites)
                  .HasForeignKey(r => r.RouteId);

            modelBuilder.HasPostgresExtension("postgis");
        }




    }
}
