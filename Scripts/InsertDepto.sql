USE [DWDistrito0503]
GO

INSERT INTO [dbo].[Departamentos]
           ([Nombre]
           ,[IdDistrito]
           ,[CreadoPor]
           ,[FechaCreado]
           ,[ModificadoPor]
           ,[FechaModificado])
     VALUES
           (<Nombre, nvarchar(255),>
           ,<IdDistrito, int,>
           ,<CreadoPor, int,>
           ,<FechaCreado, datetime,>
           ,<ModificadoPor, int,>
           ,<FechaModificado, datetime,>)
GO

