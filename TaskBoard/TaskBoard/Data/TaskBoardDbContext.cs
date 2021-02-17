using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using TaskBoard.Data.Entities;

namespace TaskBoard.Data
{
    public class TaskBoardDbContext : DbContext
    {
        public TaskBoardDbContext() : base("ScrumBoard") { }

        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Assignment entity configuration

            modelBuilder.Entity<Assignment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Assignment>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_AssignmentName") { IsUnique = false })
                );

            modelBuilder.Entity<Assignment>()
                .Property(c => c.Description)
                .HasMaxLength(300);

            #endregion

            #region Status entity configuration

            modelBuilder.Entity<Status>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Assignment>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            #endregion

            modelBuilder.Entity<Status>()
                .HasMany(status => status.Assignments)
                .WithRequired(assignment => assignment.Status)
                .HasForeignKey(assignment => assignment.StatusId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
