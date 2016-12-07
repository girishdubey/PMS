namespace PMSEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientRegistrations",
                c => new
                    {
                        RegistrationID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        Gender = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Mobileno = c.String(),
                        EmailID = c.String(),
                        Createddate = c.DateTime(),
                        Token = c.String(),
                        EncryKey = c.String(),
                        IVKey = c.String(),
                        UniqueID = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Employee_Code = c.String(nullable: false, maxLength: 80),
                        First_Name = c.String(maxLength: 20),
                        Middle_Name = c.String(maxLength: 20),
                        Last_Name = c.String(maxLength: 20),
                        Title_Id = c.Int(),
                        Date_Of_Birth = c.DateTime(),
                        Appointment_Letter_Date = c.DateTime(),
                        IsActivated = c.Boolean(),
                        ActivatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.Id, t.Employee_Code });
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Holiday_Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Holiday_Name = c.String(maxLength: 50),
                        Adjusted_Against = c.String(maxLength: 50),
                        Adjusted_Date = c.DateTime(nullable: false, storeType: "date"),
                        Optional = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Holiday_Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Shift_Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Is_General_Shift = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shift_Id, t.Name });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shifts");
            DropTable("dbo.Holidays");
            DropTable("dbo.Employees");
            DropTable("dbo.ClientRegistrations");
        }
    }
}
