using Padarogga.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Padarogga.Server.Data
{
    public class PadaroggaContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public PadaroggaContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {


        }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RouteType> RouteTypes { get; set; }

        public DbSet<Waypoint> Waypoints { get; set; }

        public DbSet<RouteWaypoints> WaypointRoutes { get; set; }

        public DbSet<RouteRating> Ratings { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<RouteComment> RouteComments { get; set; }

        public DbSet<WaypointComment> WaypointComments { get; set; }      

        public DbSet<FavoriteRoute> FavoriteRoutes { get; set; }

        public DbSet<FavoriteWaypoint> FavoriteWaypoints { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<RoutePayment> RoutePayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //CustomerRating
            modelBuilder.Entity<RouteRating>()
                .HasKey(r => new { r.CustomerId, r.RouteId });

            modelBuilder.Entity<RouteRating>()
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.Ratings)
                    .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<RouteRating>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Ratings)
                   .HasForeignKey(r => r.RouteId);

            //Route comment
            modelBuilder.Entity<RouteComment>()
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.RouteComments)
                    .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<RouteComment>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Comments)
                  .HasForeignKey(r => r.RouteId);
            //Waypoint comment
            modelBuilder.Entity<WaypointComment>()
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.WaypointComments)
                    .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<WaypointComment>()
                  .HasOne(c => c.Waypoint)
                  .WithMany(s => s.Comments)
                  .HasForeignKey(r => r.WaypointId);
            //Favorites routes
            modelBuilder.Entity<FavoriteRoute>()
              .HasKey(r => new { r.CustomerId, r.RouteId });

            modelBuilder.Entity<FavoriteRoute>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.FavoriteRoutes)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<FavoriteRoute>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Favorites)
                  .HasForeignKey(r => r.RouteId);

            //waypoint routes
            modelBuilder.Entity<RouteWaypoints>()
           .HasKey(r => new { r.WaypointId, r.RouteId });

            modelBuilder.Entity<RouteWaypoints>()
                .HasOne(c => c.Waypoint)
                .WithMany(s => s.Routes)
                .HasForeignKey(r => r.WaypointId);

            modelBuilder.Entity<RouteWaypoints>()
                  .HasOne(c => c.Route)
                  .WithMany(s => s.Waypoints)
                  .HasForeignKey(r => r.RouteId);

            //Favorites waypoints
            modelBuilder.Entity<FavoriteWaypoint>()
              .HasKey(r => new { r.CustomerId, r.WaypointId });

            modelBuilder.Entity<FavoriteWaypoint>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.FavoriteWaypoints)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<FavoriteWaypoint>()
                  .HasOne(c => c.Waypoint)
                  .WithMany(s => s.Favorites)
                  .HasForeignKey(r => r.WaypointId);

            //postgis
            modelBuilder.HasPostgresExtension("postgis");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            //created, updated dates
            var entries = ChangeTracker
                   .Entries()
                   .Where(e => e.Entity is BaseEntity && (
                           e.State == EntityState.Added
                           || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync();
        }




    }
}
