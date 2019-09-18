Select  * From Process

Create Procedure SP_Insert_Process

@Name Varchar(60),
@Id_Case Int
 As

	Begin Transaction
			Begin Try
	    	Insert Into Process(Name,Id_Case)
			Values (@Name, @Id_Case)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Select * From Process


Create Table Process(
Id Int PRimary key identity,
Id_Case Int NOt null,
Correlative int,
Name varchar (50)
);

Select * from Process_Field

drop table Process

Create Procedure SP_Delete_Process

Alter Table Process_Field
Add Constraint FK_Process_Id_PRocess
foreign Key (Id_Process) References Process (Id)

Alter Table Process 
add constraint FK_Id_Case_cASE
Foreign Key (Id_Case) References dbo.[User] (Id)

@Id int

 As

	Begin Transaction
			Begin Try
	    	Delete From Process where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Create Procedure SP_Select_Process

 As

	Begin Transaction
			Begin Try
	    	Select Id, Name, Description, Created_On From Process
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Update_Process

@Id Int,
@Name Varchar (60),
@Id_Case int 

 As

	Begin Transaction
			Begin Try
	    	Update Process Set Name=@Name, Id_Case=@Id_Case Where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch