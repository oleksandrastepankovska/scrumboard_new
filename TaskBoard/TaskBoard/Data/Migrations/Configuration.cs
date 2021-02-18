namespace TaskBoard.Data.Migrations
{
    using System.Collections.Generic;
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

            var personOlexandra = new Person { Id = 1, FirstName = "Olexandra", LastName = "Stepankovska" };
            var personSanya = new Person { Id = 2, FirstName = "Sanya", LastName = "Belyi" };
            var personOlexandr = new Person { Id = 3, FirstName = "Olexandr", LastName = "Makedonskyi" };
            context.Person.AddOrUpdate(personOlexandra);
            context.Person.AddOrUpdate(personSanya);
            context.Person.AddOrUpdate(personOlexandr);

            context.Project.AddOrUpdate(
                new Project
                {
                    Id = 1,
                    Name = "Task Board",
                    Description = "Examination project in university",
                    Assignees = new List<Person>() { personOlexandra }
                },
                new Project { 
                    Id = 2,
                    Name = "Brigada",
                    Description = "Recketing gang"
                });

            context.Assignment.AddOrUpdate(
                new Assignment
                {
                    Id = 1,
                    Name = "Pass examination",
                    Description = string.Empty,
                    StatusId = 2,
                    AssigneeId = personOlexandra.Id,
                    ProjectId = 1
                },
                new Assignment { 
                    Id = 2,
                    Name = "Finish program",
                    Description = string.Empty,
                    StatusId = 3,
                    AssigneeId = personOlexandr.Id,
                    ProjectId = 1
                },
                new Assignment
                {
                    Id = 3,
                    Name = "Earn money and respect",
                    Description = "Find a way to earn money and respect",
                    StatusId = 2,
                    AssigneeId = personSanya.Id,
                    ProjectId = 2
                });
        }
    }
}
