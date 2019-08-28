use SistemaGCDDB;

Create Procedure SP_Insert_Company

@Id_Suscription int,
@Email Varchar(60),
@Name Varchar(60),
@Address Varchar (50),
@Phone int,
@Pass Varchar(60)

As
	Begin Transaction
		Begin Try
			Insert Into Company (Id_Suscription, Email, Name, Address, Phone, Pass)
			Values (@Id_Suscription, @Email, @Name, @Address, @Phone, @Pass)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Delete_Company

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

Create Procedure SP_Update_Company

@Id Int,
@Id_Suscription int,
@Email Varchar(60),
@Name Varchar(60),
@Address Varchar (50),
@Phone int,
@Pass Varchar(60)

As
	Begin Transaction
		Begin Try
			UPDATE Company
				SET Id_Suscription = @Id_Suscription, Email=@Email, Name = @Name, Address = @Address, Phone= @Phone, Pass=@Pass
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;


Create Procedure SP_Select_Company

As
	Begin Transaction
		Begin Try
			SELECT Id, Id_Suscription,Email, Name, Address, Phone, Pass, Created_On
			FROM Company;
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;