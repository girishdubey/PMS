namespace PMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        PrimaryInformation_Id = c.Int(nullable: false),
                        Employee_Code = c.String(nullable: false, maxLength: 80),
                        Title_Id = c.Int(),
                        Date_Of_Birth = c.DateTime(),
                        MaritalStatus_Id = c.Int(),
                        BloodGroup_Id = c.Int(),
                        Anniversary_Date = c.DateTime(),
                        Correspondence_Address = c.String(maxLength: 250),
                        Permanent_Address = c.String(maxLength: 250),
                        Mobile_Number = c.String(maxLength: 30),
                        Landline_Number = c.String(maxLength: 30),
                        Work_Phone_Ext = c.String(maxLength: 20),
                        Work_Phone_Number = c.String(maxLength: 50),
                        Passport_Number = c.String(maxLength: 50),
                        Date_Of_Issue = c.DateTime(),
                        Expiry_Date = c.DateTime(),
                        Place_of_Issue = c.String(maxLength: 100, unicode: false),
                        Gender_Id = c.Int(),
                        State_of_Origin = c.String(maxLength: 50),
                        Willing_to_Relocate = c.String(maxLength: 5),
                        Personal_EmailId = c.String(maxLength: 50),
                        EmploymentType_Id = c.Int(),
                        Country_Id = c.Int(),
                        City_Id = c.Int(),
                        Location_Id = c.Int(),
                        AttendanceMethodology_Id = c.Int(),
                        Shift_Pattern_Id = c.Long(),
                        Nationality = c.String(maxLength: 20),
                        Fathers_Name = c.String(maxLength: 50),
                        Mothers_Name = c.String(maxLength: 50),
                        Spouse_Name = c.String(maxLength: 50),
                        Dependent1 = c.String(maxLength: 50),
                        Dependent2 = c.String(maxLength: 50),
                        State_Id = c.Int(),
                        Grade_Id = c.Int(),
                        Join_Date = c.DateTime(),
                        Confirmation_Date = c.DateTime(),
                        Probation_Period = c.Int(),
                        Official_EmailId1 = c.String(maxLength: 50),
                        Official_EmailId2 = c.String(maxLength: 50),
                        Seperated = c.Boolean(),
                        First_Name = c.String(maxLength: 20),
                        Middle_Name = c.String(maxLength: 20),
                        Last_Name = c.String(maxLength: 20),
                        CompanyDepartment_Id = c.Int(),
                        CmpDepartmentProcess_Id = c.Int(),
                        CompanyDesignation_Id = c.Int(),
                        Employment_Status = c.String(maxLength: 20),
                        Country_Code = c.String(maxLength: 20, unicode: false),
                        Department_Id = c.Int(),
                        Process_Id = c.Int(),
                        Designation_Id = c.Int(),
                        Company_Id = c.Int(),
                        BusinessVertical_Id = c.Int(),
                        Duration = c.Int(),
                        Contract_UpTo_Date = c.DateTime(),
                        roster = c.Boolean(),
                        Branch_Id = c.Int(),
                        Last_Working_Date = c.DateTime(),
                        Adhar_No = c.String(maxLength: 12, unicode: false),
                        PF_No = c.String(maxLength: 25),
                        ESIC_No = c.String(maxLength: 30),
                        IsActivated = c.Boolean(),
                        ActivatedOn = c.DateTime(),
                        NoticePeriod_Id = c.Int(),
                        Next_Appraisal_Date = c.DateTime(storeType: "date"),
                        IsJoined = c.Boolean(),
                        Appointment_Letter_Date = c.DateTime(),
                        Confirmation_Letter_Date = c.DateTime(),
                        Image_Upload_Status = c.Boolean(),
                        Image_Upload_Date = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PrimaryInformation_Id, t.Employee_Code });
            
            CreateTable(
                "dbo.Master_Status",
                c => new
                    {
                        Request_Status_Id = c.Short(nullable: false, identity: true),
                        Request_Status = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.Request_Status_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Master_Status");
            DropTable("dbo.Employee");
        }
    }
}
