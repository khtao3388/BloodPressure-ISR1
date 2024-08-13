using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodPressure.Models;

    public class BPReadingContext : DbContext
    {
        public BPReadingContext (DbContextOptions<BPReadingContext> options)
            : base(options)
        {
        }

        public DbSet<BPReading> BPReading { get; set; } = default!;

        public DbSet<Month> Months { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Month>()
                .HasIndex(m => new { m.YearNumber, m.MonthNumber })
                .IsUnique();
        }
}
