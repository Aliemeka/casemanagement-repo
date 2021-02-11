namespace ministryofjusticeWebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "DepartmentId", newName: "Department_Id");
            AlterColumn("dbo.AspNetUsers", "Department_Id", c => c.Byte());
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            AlterColumn("dbo.AspNetUsers", "Department_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "Department_Id", newName: "DepartmentId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
