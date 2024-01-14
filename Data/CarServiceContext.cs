using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

namespace CarService.Data
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options)
        {
        }

        public DbSet<CarService.Models.Service> Service { get; set; } = default!;

        public DbSet<CarService.Models.Room>? Room { get; set; }

        public DbSet<CarService.Models.Group>? Group { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships here

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Appointment)
                .WithOne(a => a.Service)
                .HasForeignKey<Service>(s => s.AppointmentID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CarService.Models.Client>? Client { get; set; }
    }
}
