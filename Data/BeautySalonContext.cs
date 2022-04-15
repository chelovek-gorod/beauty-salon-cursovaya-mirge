#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Models;

namespace BeautySalon.Data
{
    public class BeautySalonContext : DbContext
    {
        public BeautySalonContext (DbContextOptions<BeautySalonContext> options)
            : base(options)
        {
        }

        public DbSet<BeautySalon.Models.Employee> Employee { get; set; }

        public DbSet<BeautySalon.Models.Schedule> Schedule { get; set; }

        public DbSet<BeautySalon.Models.Service> Service { get; set; }

        public DbSet<BeautySalon.Models.Client> Client { get; set; }

        public DbSet<BeautySalon.Models.Order> Order { get; set; }
    }
}
