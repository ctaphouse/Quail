using Microsoft.EntityFrameworkCore;
using Quail.Api.Persistence.Entities;

namespace Quail.Api.Persistence;

public class QuailContext: DbContext
{
public QuailContext(DbContextOptions<QuailContext> options) : base(options)
{
    
}

public DbSet<Student>? Students { get; set; }
public DbSet<Department>? Departments { get; set; }
public DbSet<Course>? Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
        .HasMany(c => c.Students)
        .WithMany(s => s.Courses)
        .UsingEntity<CourseStudent>(
            j => j.HasOne<Student>(j => j.Student).WithMany().HasForeignKey(j => j.StudentId),
            j => j.HasOne<Course>(j => j.Course).WithMany().HasForeignKey(j => j.CourseId));
    }
}