using KeysetPagination.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KeysetPagination.Infrastructure.Database;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
        .HasKey((s) => s.Id)
        .HasName("PK_Student_Id");

        modelBuilder.Entity<Student>()
        .Property((s) => s.Id)
        .IsRequired();

        modelBuilder.Entity<Student>()
        .Property((s) => s.FirstName)
        .HasMaxLength(200)
        .IsRequired();

        modelBuilder.Entity<Student>()
        .Property((s) => s.LastName)
        .HasMaxLength(200)
        .IsRequired();

        modelBuilder.Entity<Student>()
        .Property((s) => s.DateOfBirth)
        .IsRequired();

        modelBuilder.Entity<Student>()
        .HasIndex(s => s.CreatedUtcTicks)
        .HasDatabaseName("IX_Students_CreatedUtcTicks");

        base.OnModelCreating(modelBuilder);
    }
}

