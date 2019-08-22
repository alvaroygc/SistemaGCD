Create Procedure SP_Insert_User
@Name Varchar(60),
@Email Varchar (50),
@Description Varchar(60),
@Pass Varchar (60)

 As

	Begin Transaction
			Begin Try
	    	Insert Into [User] (Name,Email,Description,Pass)
			Values (@Name, @Email, @Description, (SELECT CONVERT(NVARCHAR(32),HashBytes('MD5', @Pass),2)))
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Delete_User

@Id int

 As

	Begin Transaction
			Begin Try
	    	Delete From [User] Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Update_User

@Id int,
@Name Varchar(60),
@Email Varchar (50),
@Description Varchar(60),
@Pass Varchar (60)

 As

	Begin Transaction
			Begin Try
	    	UPDATE [User]
				SET Name = @Name, Email = @Email, Description = @Description, Pass = (SELECT CONVERT(NVARCHAR(32),HashBytes('MD5', @Pass),2))
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Select_User

 As

	Begin Transaction
			Begin Try
	    		Select Id, Name, Email, Description, Pass, Created_On From [User]
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

CREATE Procedure SP_SelectById_User

@Id int

As
	Begin Transaction
		Begin Try
			Select Name, Email, Description, Pass, Created_On From [User] Where Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Execute SP_SelectById_User 1