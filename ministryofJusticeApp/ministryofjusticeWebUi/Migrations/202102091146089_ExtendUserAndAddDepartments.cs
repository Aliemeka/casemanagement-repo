namespace ministryofjusticeWebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendUserAndAddDepartments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department_Id", c => c.Byte());
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            DropColumn("dbo.AspNetUsers", "Department_Id");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Departments");
        }
    }
}
