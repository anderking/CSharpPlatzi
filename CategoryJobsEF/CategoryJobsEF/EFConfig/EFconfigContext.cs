using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsEF.Models;

namespace CategoryJobsEF.EFconfig
{
    public class EFconfigContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public EFconfigContext(DbContextOptions<EFconfigContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.Id);

                category.Property(p => p.Name).IsRequired();

                category.Property(p => p.Description).HasMaxLength(1000);

                category.Property(p => p.CreatedDate);

                category.Property(p => p.ModifedDate);
            });

            modelBuilder.Entity<Job>(job =>
            {
                job.ToTable("Job");
                job.HasKey(p => p.Id);

                job.HasOne(p => p.Category).WithMany(p => p.Jobs).HasForeignKey(p => p.IdCategory);

                job.Property(p => p.Name).IsRequired();

                job.Property(p => p.Description).HasMaxLength(1000);

                job.Property(p => p.Priority);

                job.Property(p => p.CreatedDate);

                job.Property(p => p.ModifedDate);
            });
        }
    }
}
