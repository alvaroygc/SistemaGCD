Create Procedure SP_Insert_Data_Type

@Name Varchar(60),
@Description Varchar (50)

 As

	Begin Transaction
			Begin Try
	    	Insert Into Data_Type (Name,Description)
			Values (@Name, @Description)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Create Procedure SP_Delete_Data_Type

@Id int

 As

	Begin Transaction
			Begin Try
	    	Delete From Data_Type where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Create Procedure SP_Select_Data_Type

 As

	Begin Transaction
			Begin Try
	    	Select Id, Name, Description From Data_Type
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Update_Data_Type

@Id Int,
@Name Varchar (60),
@Description Varchar (60)

 As

	Begin Transaction
			Begin Try
	    	Update Data_Type Set Name=@Name, Description=@Description Where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch