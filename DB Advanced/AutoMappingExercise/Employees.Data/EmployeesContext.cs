using System;
using Microsoft.EntityFrameworkCore;
using Employees.Models;

namespace Employees.Data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {
            
        }

        public EmployeesContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Address)
                    .HasMaxLength(250);

                entity.Ignore(e => e.ManagerName);

                entity.HasOne(e => e.Manager)
                    .WithMany(e => e.ManagedEmployees)
                    .HasForeignKey(e => e.ManagerId)
                    .IsRequired(false);
            });
        }

    }
}
