using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsBlazor.Models;

namespace CategoryJobsBlazor.EFconfig
{
    public class EFconfigContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=(localdb)\\anderking;Initial Catalog=dev;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.Id);
                category.Property(p => p.Code).IsRequired();
                category.Property(p => p.Name).IsRequired();
                category.Property(p => p.State);
                category.Property(p => p.StateDelete);
                category.Property(p => p.StateModified);
                category.Property(p => p.CreatedDate).IsRequired();
                category.Property(p => p.CreatedUserName).IsRequired();
                category.Property(p => p.CreatedUserEmail).IsRequired();
                category.Property(p => p.ModifiedDate);
                category.Property(p => p.ModifiedUserName);
                category.Property(p => p.ModifiedUserEmail);
                category.Property(p => p.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<Job>(job =>
            {
                job.ToTable("Job");
                job.HasKey(p => p.Id);
                job.Property(p => p.Code).IsRequired();
                job.Property(p => p.Name).IsRequired();
                job.Property(p => p.State);
                job.Property(p => p.StateDelete);
                job.Property(p => p.StateModified);
                job.Property(p => p.CreatedDate).IsRequired();
                job.Property(p => p.CreatedUserName).IsRequired();
                job.Property(p => p.CreatedUserEmail).IsRequired();
                job.Property(p => p.ModifiedDate);
                job.Property(p => p.ModifiedUserName);
                job.Property(p => p.ModifiedUserEmail);
                job.HasOne(p => p.Category).WithMany(p => p.Jobs).HasForeignKey(p => p.IdCategory);
                job.Property(p => p.Description).HasMaxLength(1000);
                job.Property(p => p.Priority);
            });
        }
    }
}
