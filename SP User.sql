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


Select * from Token;

Create Procedure SP_Insert_Login
@Text Varchar(60),
@Expired_dt datetime,
@Status Varchar(15),
@Created_dt datetime,
@Id_User int

 As

	Begin Transaction
			Begin Try
	    	Insert Into [Token] ([Text],Expired_dt,[Status],Created_dt,Id_User)
			Values (@Text,@Expired_dt,@Status,@Created_dt,@Id_User)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create procedure SP_Select_Token

@Text varchar(60)

As

	Begin Transaction 
		Begin Try
			Select Id, [Text], Expired_dt, [Status] from Token where [Text]=@Text
			commit
		End Try
		Begin Catch 
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch;

		Select * From Token;

Create Procedure SP_Update_Token

@text Varchar(60)

 As

	Begin Transaction
			Begin Try
	    	UPDATE Token
				SET Status = 'USED'
			WHERE Text=@text;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Execute SP_Update_Token '0ff9be64-0760-45a4-b888-1446262d6e8d'