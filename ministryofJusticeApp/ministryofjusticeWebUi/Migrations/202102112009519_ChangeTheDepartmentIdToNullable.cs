namespace ministryofjusticeWebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTheDepartmentIdToNullable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Department_Id", newName: "DepartmentId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Department_Id", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_DepartmentId", newName: "IX_Department_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "DepartmentId", newName: "Department_Id");
        }
    }
}
