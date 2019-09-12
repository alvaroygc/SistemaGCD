Create Database SistemaGCDDB;

Use SistemaGCDDB;

Create Table Allowed_Action (
Id Int Primary Key Not Null Identity,
Name Varchar(60) not null,
Description Varchar(60) not null,
Created_On Datetime default getdate()
);

Create Table Role (
Id Int Primary Key Not Null Identity,
Name Varchar(60) not null,
Description Varchar(60) not null,
Created_On Datetime default getdate()
);

Create Table [User] (
Id Int Primary Key Not Null Identity,
Name Varchar(60) Not Null,
Email Varchar(60) Not Null,
Description Varchar(60) Not Null,
Pass Varchar(60) Not Null,
Created_On Datetime default getdate()
);

Create Table Objet_Type(
Id Int Primary Key Not Null Identity,
Name Varchar(60) Not Null,
Description Varchar (60) Not Null,
Created_On Datetime Default Getdate()
);

Create Table Sec_Object (
Id Int Primary Key Not Null Identity,
Id_Object_Type Int Not Null,
Name Varchar(60) Not Null,
Description Varchar(60) Not Null,
Created_On Datetime Default GetDate()
);

Create Table Role_Detail (
Id_Role Int Not Null,
Id_Allowed_Action Int Not Null,
Id_Sec_Object Int Not Null,
Created_On DateTime Default GetDate(),
Primary Key (Id_Role, Id_Allowed_Action, Id_Sec_Object)
);

Create Table User_Role(
Id_User Int Not Null,
Id_Role Int Not Null,
Created_On DateTime Default GetDate(),
Primary Key  (Id_User, Id_Role)
);

Create Table Suscription (
Id Int Primary Key Not Null Identity,
Name Varchar(60) Not Null,
Description Varchar (60) Not Null,
Number_Case Int Not null,
Created_On Datetime Default Getdate()
);



Create Table Company(
Id Int Primary Key Not Null Identity,
Id_Suscription Int Not Null,
Email Varchar(60) Not Null,
Name Varchar(100) Not Null,
Address Varchar(80) Not Null,
Phone Int Not Null,
Pass Varchar(80) Not Null,
Created_On Datetime Default Getdate()
);

Create Table Logs (
Id int primary key identity,
Name_Procedure varchar(50),
Message Varchar(MAX),
Created_On Datetime default getdate()
);

Create Table Audit_Logs(
Id Int Primary Key Identity,
Id_User Int Not Null,
Action_Name Varchar (50) Not null,
Object_Name Varchar (50) Not null,
Params_Send Varchar (Max) Not null,
Log_Date Datetime Default getdate()
);

Create Table [Status] (
Id int primary key identity,
Name Varchar(100) Not null,
Description Varchar(100) Not null,
Created_On Datetime default Getdate()
);


Alter Table User_Role
Add Constraint FK_User_Role_User
Foreign Key (Id_User) References [User] (Id);

Alter Table User_Role
Add Constraint FK_User_Role_Role
Foreign Key (Id_Role) References Role (Id);

Alter Table Sec_Object
Add Constraint Fk_Object_Type_Id
Foreign Key (Id_Object_Type) References Object_Type (Id);

Alter Table Role_Detail 
Add Constraint Fk_Role_Detail_Allowed_Action
Foreign Key (Id_Allowed_Action) References Allowed_Action(Id);

Alter Table Role_Detail 
Add Constraint Fk_Role_Detail_Role
Foreign Key (Id_Role) References Role (Id);

Alter Table Role_Detail
Add Constraint Fk_Role_Detail_Sec_Object
Foreign Key (Id_Sec_Object) References Sec_Object (Id);

Alter Table Company
Add Constraint FK_Role_Detail_Id_Suscription
Foreign Key (Id_Suscription) References Suscription (Id);

Alter Table Audit_Logs
Add Constraint FK_Audit_Logs_Id_User
Foreign Key (Id_User) References [User] (Id);

Alter Table [User]
Add Constraint FK_Users_Id_Company
Foreign Key (Id_Company) References Company (Id);