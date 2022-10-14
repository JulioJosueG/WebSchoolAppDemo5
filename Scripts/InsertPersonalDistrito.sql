USE [DWDistrito0503]
GO

INSERT INTO [dbo].[PersonalDistrito]
           ([Nombre]
           ,[Apellido]
           ,[Cedula]
           ,[IdDepartamento]
           ,[IdDistrito]
           ,[CreadoPor]
           ,[FechaCreado]
           ,[ModificadoPor]
           ,[FechaModificado])
     VALUES
           (<Nombre, nvarchar(255),>
           ,<Apellido, nvarchar(255),>
           ,<Cedula, nvarchar(11),>
           ,<IdDepartamento, int,>
           ,<IdDistrito, int,>
           ,<CreadoPor, int,>
           ,<FechaCreado, datetime,>
           ,<ModificadoPor, int,>
           ,<FechaModificado, datetime,>)
GO

