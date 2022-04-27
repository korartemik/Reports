#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.Models;

namespace Reports.Data
{
    public class ReportsContext : DbContext
    {
        public ReportsContext (DbContextOptions<ReportsContext> options)
            : base(options)
        {
        }

        public DbSet<Reports.Models.Post> Post { get; set; }

        public DbSet<Reports.Models.Task> Task { get; set; }

        public DbSet<Reports.Models.Person> Person { get; set; }
    }
}
