Use SistemaGCDDB;

Create Procedure SP_Insert_Object_Type

@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			Insert Into Object_Type (Name,Description)
			Values (@Name, @Description)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Delete_Object_Type

@Id Int

As
	Begin Transaction
		Begin Try
			Delete From Object_Type Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Update_Object_Type

@Id Int,
@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			UPDATE Object_Type
				SET Name = @Name, Description = @Description
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Select_Object_Type

As
	Begin Transaction
		Begin Try
			SELECT Id, Name, Description, Created_On
			FROM Allowed_Action;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

CREATE Procedure SP_SelectById_Object_Type

@Id int

As
	Begin Transaction
		Begin Try
			Select Name, Description, Created_On From Object_Type Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;