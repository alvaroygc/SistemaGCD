use SistemaGCDDB;

Select * From [Case]

Create Procedure SP_Insert_Case

@Id_Company Int,
@Name Varchar(60),
@Description Varchar (50),
@Created_By Int,
@Id_Status Int

As
	Begin Transaction
		Begin Try
			Insert Into [Case] (Id_Company,Name,Description,Created_By,Id_Status)
			Values (@Id_Company,@Name, @Description,@Created_By,@Id_Status)
		Commit
		End Try
		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch;

Create Procedure SP_Delete_Case

@Id Int

As
	Begin Transaction
		Begin Try
			Delete From [Case] Where Id=@Id
		Commit
		End Try

		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch;

Create Procedure SP_Update_Case

@Id Int,
@Id_Company Int,
@Name Varchar(60),
@Description Varchar (50),
@Created_By Int,
@Id_Status Int

As
	Begin Transaction
		Begin Try
			UPDATE [Case]
				SET Id_Company=@Id_Company, Name = @Name, Description = @Description,Created_By=@Created_By, Id_Status=@Id_Status
			WHERE Id=@Id;
		Commit
		End Try

		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch;


Create Procedure SP_Select_Case

As
	Begin Transaction
		Begin Try
			SELECT [Case].Id, [Case].Id_Company, Company.Name as Company_Name ,[Case].Name, [Case].Description, [Case].Created_By, [User].Name,[Case].Created_On, [Case].Id_Status, Status.Name
			FROM [Case]
			Inner Join Company on [Case].Id_Company = Company.Id
			Inner Join Status on [Case].Id_Status = Status.Id
			Inner Join [User] on [Case].Created_By = [User].Id
		Commit
		End Try

		Begin Catch
		Rollback
		Insert Into Logs (Name_Procedure, Message) Values (object_name(@@PROCID),ERROR_MESSAGE())
		Print 'Error en la Transaccion'
		End Catch;


Insert Into [Case] (Id_Company, Name,Description,Created_By,Id_Status) Values (6,'Contrato', 'Contrato de Personal', 3,1)

Select *From [Case]

Execute SP_Select_Case