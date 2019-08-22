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

Create Procedure SP_Delete_Allowed_Action

@Id Int

As
	Begin Transaction
		Begin Try
			Delete From Allowed_Action Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Update_Allowed_Action

@Id Int,
@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			UPDATE Allowed_Action
				SET Name = @Name, Description = @Description
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;


Create Procedure SP_Select_Allowed_Action

As
	Begin Transaction
		Begin Try
			SELECT Id, Name, Description
			FROM Allowed_Action;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;
