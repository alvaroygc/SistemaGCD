use SistemaGCDDB;

Create Table [Status] (
Id int primary key identity,
Name Varchar(100) Not null,
Description Varchar(100) Not null,
Created_On Datetime default Getdate()
);

Create Table Data_Type (
Id Int Primary Key Identity,
Name Varchar(50) Not Null,
Description Varchar (50) Not Null
);

Create Table [Case](
Id Int Primary Key Identity,
Id_Company Int Not Null,
Name Varchar (50) Not Null,
Description Varchar (50) Not Null,
Created_By Int Not Null,
Created_On Datetime Default GetDate(),
Id_State Int Not Null
);


Create Table Process (
Id Int Primary Key Identity,
Id_Case Int Not Null,
Correlative Int Not Null,
Name Varchar (50) Not Null
);

Create Table Process_Field(
Id Int Primary Key Identity,
Id_Process Int Not Null,
Name Varchar (50) Not Null,
Archive bit Not Null,
Id_Data_Type Int Not Null
);

Alter Table [Case]
Add Constraint FK_Company_Id_Company
Foreign Key (Id_Company) References Company (Id);

Alter Table [Case]
Add Constraint FK_Status_Id_Status_Id
Foreign Key (Id_Status) References [Status] (Id);

Alter Table [Case]
Add Constraint FK_Created_BY
Foreign Key (Created_By) References [User] (Id);

Alter Table Process
Add Constraint FK_Process_Process_Id
Foreign Key (Id_Case) References [Case] (Id);

Alter Table Process_Field
Add Constraint FK_Process_Id_Process
Foreign Key (Id_Process) References Process (Id);

Alter Table Process_Field
Add Constraint FK_Data_Id_Data_Type
Foreign Key (Id_Data_Type) References Data_Type (Id);