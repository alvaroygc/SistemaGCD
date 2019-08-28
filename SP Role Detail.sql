use SistemaGCDDB;

Create Procedure SP_Select_Role_Detail

As
	Begin Transaction
		Begin Try
			Select [Role].Id, [Role].Name, Allowed_Action.Id, Allowed_Action.Name, Sec_Object.id, Sec_Object.Name
				From Role_Detail
			Inner Join Allowed_Action On Role_Detail.Id_Allowed_Action = Allowed_Action.Id  
			Inner Join Sec_Object On Role_Detail.Id_Sec_Object = Sec_Object.Id
			Inner Join [Role] On Role_Detail.Id_Role = [Role].Id
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

Create Procedure SP_Insert_Role_Detail

@Id_Role int,
@Id_Allowed_Action int,
@Id_Sec_Object int

As
	Begin Transaction
		Begin Try
			Insert Into Role_Detail (Id_Role, Id_Allowed_Action, Id_Sec_Object) 
			Values (@Id_Role, @Id_Allowed_Action, @Id_Sec_Object)
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;


Create Procedure SP_Delete_Role_Detail

@Id_Role int,
@Id_Allowed_Action int,
@Id_Sec_Object int

As
	Begin Transaction
		Begin Try
			Delete From Role_Detail Where Id_Allowed_Action=@Id_Allowed_Action and Id_Role=@Id_Role and Id_Sec_Object=@Id_Sec_Object 
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;


Create Procedure SP_Update_Role_Detail

@Id_Role int,
@Id_Allowed_Action int,
@Id_Sec_Object int

As
	Begin Transaction
		Begin Try
			UPDATE Role_Detail
				SET Id_Role = @Id_Role, Id_Allowed_Action = @Id_Allowed_Action, Id_Sec_Object=@Id_Sec_Object
			WHERE Id_Allowed_Action=@Id_Allowed_Action and Id_Role=@Id_Role and Id_Sec_Object=@Id_Sec_Object 
		Commit
		End Try

		Begin Catch
		Print 'Error en la Transaccion'
		Rollback
		End Catch;




