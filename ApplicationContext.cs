using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;

namespace TaskManagementApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskManagement;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.ToTable("Tasks", t =>
                {
                    t.HasCheckConstraint("CK_Task_DueDate", "[DueDate] >= [CreatedDate]");
                });

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.HasIndex(e => e.CreatedDate);

                entity.HasIndex(e => e.Title)
                    .IsUnique();

                entity.HasData(
                    new TaskEntity
                    {
                        Id = 1,
                        Title = "Initial Task",
                        Description = "This is an initial task.",
                        CreatedDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        Status = TaskStatusEnum.Pending
                    }
                );
            });
        }

    }
}
