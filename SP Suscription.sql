use SistemaGCDDB;

Create Procedure SP_Insert_Suscription

@Name Varchar(60),
@Description Varchar (50),
@Number_Case int 

As
	Begin Transaction
		Begin Try
			Insert Into Suscription (Name,Description, Number_Case)
			Values (@Name, @Description, @Number_Case)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Delete_Suscription

@Id Int

As
	Begin Transaction
		Begin Try
			Delete From Suscription Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Update_Suscription

@Id Int,
@Name Varchar(60),
@Description Varchar (50),
@Number_Case int

As
	Begin Transaction
		Begin Try
			UPDATE Suscription
				SET Name = @Name, Description = @Description, Number_Case=@Number_Case
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;


Create Procedure SP_Select_Suscription 

As
	Begin Transaction
		Begin Try
			SELECT Id, Name, Description, Number_Case, Created_On
			FROM Suscription;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;
