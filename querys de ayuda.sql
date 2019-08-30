USE [SistemaGCDDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Object_Type]    Script Date: 29/08/2019 22:48:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[SP_Delete_Object_Type]

@Id int,

As
	Begin Transaction
		Begin Try
			Delete From Object_Type Where Id=@Id
		Commit
		End Try

		Begin Catch
		SELECT  
			ERROR_NUMBER() AS ErrorNumber  
            ,ERROR_SEVERITY() AS ErrorSeverity  
            ,ERROR_STATE() AS ErrorState  
            ,ERROR_PROCEDURE() AS ErrorProcedure  
            ,ERROR_LINE() AS ErrorLine  
            ,ERROR_MESSAGE() AS ErrorMessage  
		Print 'Error en la Transaccion'
		Rollback
		End Catch;

		DECLARE @r decimal;
execute SP_Delete_Allowed_Action 2,@r output;
PRINT @r;
