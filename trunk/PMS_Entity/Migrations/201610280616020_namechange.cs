namespace PMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employee_PrimaryInformation_Master_5", newName: "Employees");
            RenameTable(name: "dbo.General_Request_Status_Master_299", newName: "Master_Status");
            DropTable("dbo.General_Request_Type_Master_300");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.General_Request_Type_Master_300",
                c => new
                    {
                        Request_Type_Id = c.Short(nullable: false),
                        Request_Type = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => new { t.Request_Type_Id, t.Request_Type });
            
            RenameTable(name: "dbo.Master_Status", newName: "General_Request_Status_Master_299");
            RenameTable(name: "dbo.Employees", newName: "Employee_PrimaryInformation_Master_5");
        }
    }
}
