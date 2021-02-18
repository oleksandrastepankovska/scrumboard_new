namespace TaskBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Extending_with_projects_persons : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Assignments", "IX_AssignmentName");
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "IX_ProjectName");
            
            CreateTable(
                "dbo.ProjectPersons",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Person_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Person_Id);
            
            AddColumn("dbo.Assignments", "AssigneeId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignments", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Assignments", "Description", c => c.String());
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Assignments", "Name", name: "IX_AssignmentName");
            CreateIndex("dbo.Assignments", "AssigneeId");
            CreateIndex("dbo.Assignments", "ProjectId");
            AddForeignKey("dbo.Assignments", "AssigneeId", "dbo.People", "Id");
            AddForeignKey("dbo.Assignments", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ProjectPersons", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Assignments", "AssigneeId", "dbo.People");
            DropIndex("dbo.ProjectPersons", new[] { "Person_Id" });
            DropIndex("dbo.ProjectPersons", new[] { "Project_Id" });
            DropIndex("dbo.Projects", "IX_ProjectName");
            DropIndex("dbo.Assignments", new[] { "ProjectId" });
            DropIndex("dbo.Assignments", new[] { "AssigneeId" });
            DropIndex("dbo.Assignments", "IX_AssignmentName");
            AlterColumn("dbo.Status", "Name", c => c.String());
            AlterColumn("dbo.Assignments", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Assignments", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Assignments", "ProjectId");
            DropColumn("dbo.Assignments", "AssigneeId");
            DropTable("dbo.ProjectPersons");
            DropTable("dbo.Projects");
            DropTable("dbo.People");
            CreateIndex("dbo.Assignments", "Name", name: "IX_AssignmentName");
        }
    }
}
