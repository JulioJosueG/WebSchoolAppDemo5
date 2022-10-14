USE [DWDistrito0503]
GO

INSERT INTO [dbo].[Asignaturas]
           ([Nombre]
           ,[CreadoPor]
           ,[FechaCreado]
           ,[ModificadoPor]
           ,[FechaModificado])
     VALUES
           (<Nombre, nvarchar(255),>
           ,<CreadoPor, int,>
           ,<FechaCreado, datetime,>
           ,<ModificadoPor, int,>
           ,<FechaModificado, datetime,>)
GO

