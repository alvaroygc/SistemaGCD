use SistemaGCDDB;

Select * From Status;

Create Procedure SP_Insert_Status

@Name Varchar(60),
@Description Varchar (50)

 As

	Begin Transaction
			Begin Try
	    	Insert Into Status (Name,Description)
			Values (@Name, @Description)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Delete_Status

@Id int

 As

	Begin Transaction
			Begin Try
	    	Delete From Status where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Create Procedure SP_Select_Status

 As

	Begin Transaction
			Begin Try
	    	Select Id, Name, Description, Created_On From Status
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Update_Status

@Id Int,
@Name Varchar (60),
@Description Varchar (60)

 As

	Begin Transaction
			Begin Try
	    	Update Status Set Name=@Name, Description=@Description Where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch