Select  * From Process

Create Procedure SP_Insert_Process

@Name Varchar(60),
@Description Varchar (50)

 As

	Begin Transaction
			Begin Try
	    	Insert Into Process(Name,Description)
			Values (@Name, @Description)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Delete_Process

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
@Description Varchar (60)

 As

	Begin Transaction
			Begin Try
	    	Update Process Set Name=@Name, Description=@Description Where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch