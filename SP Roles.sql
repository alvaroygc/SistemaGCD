Use SistemaGCDDB;

Create Procedure SP_Insert_Roles

@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			Insert Into [Role] (Name,Description)
			Values (@Name, @Description)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Delete_Roles

@Id Int

As
	Begin Transaction
		Begin Try
			Delete From [Role] Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Update_Roles

@Id Int,
@Name Varchar(60),
@Description Varchar (50)

As
	Begin Transaction
		Begin Try
			UPDATE [Role]
				SET Name = @Name, Description = @Description
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Select_Roles

As
	Begin Transaction
		Begin Try
			SELECT Id, Name, Description, Created_On
			FROM [Role];
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

CREATE Procedure SP_SelectById_Roles

@Id int

As
	Begin Transaction
		Begin Try
			Select Name, Description, Created_On From [Role] Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Execute SP_Insert_Roles 'Admin Sis', 'Super admin';

Execute SP_Select_Roles;

Execute SP_SelectById_Roles 2;

Execute SP_Update_Roles '1', 'Super', 'Admins Super'