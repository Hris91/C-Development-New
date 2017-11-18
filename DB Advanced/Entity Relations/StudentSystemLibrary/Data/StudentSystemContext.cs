
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {

        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=StudentSystem;Integrated Security=True");
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name)
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(s => s.Birthday)
                    .IsRequired(false)
                    .HasColumnType("DATETIME2");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode();

                entity.Property(c => c.Description)
                    .IsUnicode()
                    .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsUnicode();

                entity.Property(r => r.Url)
                    .IsUnicode(false);

                entity.HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content)
                    .IsUnicode(false);

                entity.HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new {sc.CourseId, sc.StudentId});

                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);

            });
        }

    }
}
