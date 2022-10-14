USE [DWDistrito0503]
GO

INSERT INTO [dbo].[PersonalCentro]
           ([Nombre]
           ,[Apellido]
           ,[Cedula]
           ,[IdDepartamento]
           ,[IdCentro]
           ,[CreadoPor]
           ,[FechaCreado]
           ,[ModificadoPor]
           ,[FechaModificado])
     VALUES
           (<Nombre, nvarchar(255),>
           ,<Apellido, nvarchar(255),>
           ,<Cedula, nvarchar(11),>
           ,<IdDepartamento, int,>
           ,<IdCentro, int,>
           ,<CreadoPor, int,>
           ,<FechaCreado, datetime,>
           ,<ModificadoPor, int,>
           ,<FechaModificado, datetime,>)
GO

