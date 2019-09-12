use SistemaGCDDB;

Select * From Process_Field;

Create Procedure SP_Insert_Process_Field

@Id_Process int,
@Name Varchar(60),
@Archive bit,
@Id_Data_Type int

 As

	Begin Transaction
			Begin Try
	    	Insert Into ProcessProcess_Field(Id_Process, Name, Archive,Id_Data_Type)
			Values (@Id_Process, @Name, @Archive, @Id_Data_Type)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Delete_Process_Field

@Id int

 As

	Begin Transaction
			Begin Try
	    	Delete From Process_Field where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch

Create Procedure SP_Select_Process_Field

 As

	Begin Transaction
			Begin Try
	    	Select Process_Field.Id, Process_Field.Id_Process, Process.Name As Process_Name, Process_Field.Name, Process_Field.Archive, Process_Field.Id_Data_Type, Data_Type.Name As Data_Type_Name 
			From Process_Field
			Inner Join Process on Process_Field.Id_Process = Process.Id
			Inner Join Data_Type on Process_Field.Id_Data_Type = Data_Type.Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch


Create Procedure SP_Update_Process_Field

@Id Int,
@Id_Process int,
@Name Varchar(60),
@Archive bit,
@Id_Data_Type int

 As

	Begin Transaction
			Begin Try
	    	Update Process_Field Set Id_Process=@Id_Process, Name=@Name, Archive=@Archive, Id_Data_Type=@Id_Data_Type 
			Where Id=@Id
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch