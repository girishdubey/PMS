
SET IDENTITY_INSERT [dbo].[ClientRegistrations] ON

INSERT [dbo].[ClientRegistrations]
       ([RegistrationID],
        [FirstName],
        [Lastname],
        [Gender],
        [Username],
        [Password],
        [Mobileno],
        [EmailID],
        [Createddate],
        [Token],
        [EncryKey],
        [IVKey],
        [UniqueID])
VALUES (1,
        N'Saineshwar',
        N'Bageri',
        N'M',
        N'Saineshwar',
        N'######',
        NULL,
        NULL,
        Cast(0x0000A68700000000 AS DATETIME),
        N'QbOsqf3LZAefzwwSBKHX',
        N'18694440',
        N'BFA3EO5T',
        N'pO5zp0fTdz')

SET IDENTITY_INSERT [dbo].[ClientRegistrations] OFF

GO 


Insert into Employees(Id,Employee_Code,First_Name,Middle_Name,Last_Name,Title_Id,Date_Of_Birth,Appointment_Letter_Date,IsActivated,ActivatedOn)
values(1,'RB150457','Girish','','Dubey',1,'01-Apr-1991','01-jan-2015',1,'01-jun-2015'),
(2,'RB150458','Samridhi','','Patni',1,'01-Apr-1995','01-jan-2016',1,'01-jun-2016'),
(3,'RB150459','Prachi','','Yadav',1,'01-Apr-1995','01-jan-2016',1,'01-jun-2016'),
(4,'RB150456','Ravinder','Singh','Rana',1,'01-Apr-1985','01-jan-2010',1,'01-jun-2010')
