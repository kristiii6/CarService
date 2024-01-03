using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeautyServices.Models;

namespace BeautyServices.Data
{
    public class BeautyServicesContext : DbContext
    {
        public BeautyServicesContext (DbContextOptions<BeautyServicesContext> options)
            : base(options)
        {
        }

        public DbSet<BeautyServices.Models.Service> Service { get; set; } = default!;

        public DbSet<BeautyServices.Models.Room>? Room { get; set; }

    }
}
