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
Primary Key  (Id_User, Id_Role)
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


Create Procedure SP_Insert_Allowed_Action

@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			Insert Into Allowed_Action (Name,Description)
			Values (@Name, @Description)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Select * from Allowed_Action;

Execute SP_Insert_Allowed_Action 'Mostrar','Permiso SQL para mostrar datos';