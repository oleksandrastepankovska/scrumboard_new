namespace TaskBoard.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using TaskBoard.Data.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskBoard.Data.TaskBoardDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(TaskBoard.Data.TaskBoardDbContext context)
        {
            context.Status.AddOrUpdate(
                new Status { Id = 1, Name = "To do" },
                new Status { Id = 2, Name = "In proggress" },
                new Status { Id = 3, Name = "Done" });

            context.Assignment.AddOrUpdate(
                new Assignment { Id = 1, Name = "Pass examination", Description = string.Empty, StatusId = 2 });
        }
    }
}
