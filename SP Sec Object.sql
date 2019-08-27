use SistemaGCDDB;

Create Procedure SP_Select_Sec_Object

 As

	Begin Transaction
			Begin Try
	    		Select Sec_Object.Id, Sec_Object.Name, Sec_Object.Description, Object_Type.Name
				From Sec_Object 
					inner join Object_Type 
				on Sec_Object.Id_Object_Type = Object_Type.Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_SelectById_Sec_Object
@Id int
 As

	Begin Transaction
			Begin Try
	    		Select Sec_Object.Id, Sec_Object.Name, Sec_Object.Description, Object_Type.Name
				From Sec_Object 
					inner join Object_Type 
				on Sec_Object.Id_Object_Type = Object_Type.Id
				where Sec_Object.id = @Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Insert_Sec_Object
@Id_Object_Type int,
@Name Varchar(60),
@Description Varchar (60)

 As

	Begin Transaction
			Begin Try
	    		Insert Into Sec_Object (Id_Object_Type, Name, Description) Values (@Id_Object_Type, @Name, @Description)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Update_Sec_Object
@Id int,
@Id_Object_Type int,
@Name Varchar(60),
@Description Varchar (60)

 As

	Begin Transaction
			Begin Try
	    		UPDATE Sec_Object
					SET Id_Object_Type = @Id_Object_Type, Name = @Name, Description= @Description
					WHERE Id = @Id

		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch

Create Procedure SP_Delete_Sec_Object
@Id int

 As

	Begin Transaction
			Begin Try
	    		DELETE FROM Sec_Object WHERE Id=@Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch


Execute SP_Select_Sec_Object;

Execute SP_SelectById_Sec_Object 2;

Execute SP_Insert_Sec_Object 2,'Prueba', 'Pruebas';

Execute SP_Update_Sec_Object 2,3,'Error','Error'

Execute SP_Delete_Sec_Object 2;


