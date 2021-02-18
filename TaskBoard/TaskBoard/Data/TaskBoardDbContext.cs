using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using TaskBoard.Data.Entities;

namespace TaskBoard.Data
{
    public class TaskBoardDbContext : DbContext
    {
        public TaskBoardDbContext() : base("TaskBoard") { }

        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Assignment>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_AssignmentName") { IsUnique = false })
                );

            modelBuilder.Entity<Status>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Project>()
                .HasKey(project => project.Id);

            modelBuilder.Entity<Project>()
                .Property(project => project.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_ProjectName") { IsUnique = false })
                );

            modelBuilder.Entity<Person>()
                .HasKey(person => person.Id);

            modelBuilder.Entity<Status>()
                .HasMany(status => status.Assignments)
                .WithRequired(assignment => assignment.Status)
                .HasForeignKey(assignment => assignment.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(project => project.Assignees)
                .WithMany(person => person.Projects);

            modelBuilder.Entity<Project>()
                .HasMany(project => project.Assignments)
                .WithRequired(assignment => assignment.Project)
                .HasForeignKey(assignment => assignment.ProjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(person => person.Assignments)
                .WithRequired(assignment => assignment.Assignee)
                .HasForeignKey(assignment => assignment.AssigneeId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
