USE [DWDistrito0503]
GO
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([IdDepartamento], [Nombre], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (1, N'Administración', 1, 1, CAST(N'2022-10-13T17:00:38.820' AS DateTime), NULL, NULL)
INSERT [dbo].[Departamentos] ([IdDepartamento], [Nombre], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (2, N'RRSS', 1, 1, CAST(N'2022-10-13T17:00:48.770' AS DateTime), NULL, NULL)
INSERT [dbo].[Departamentos] ([IdDepartamento], [Nombre], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (3, N'Contabilidad', 1, 1, CAST(N'2022-10-13T17:01:29.650' AS DateTime), NULL, NULL)
INSERT [dbo].[Departamentos] ([IdDepartamento], [Nombre], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (4, N'Gestión Académica', 1, 1, CAST(N'2022-10-13T17:01:51.473' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalDistrito] ON 

INSERT [dbo].[PersonalDistrito] ([IdPersonalDistrito], [Nombre], [Apellido], [Cedula], [IdDepartamento], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (3, N'Pedro', N'Santana', N'00000000000', 2, 1, 1, CAST(N'2022-10-13T17:02:56.403' AS DateTime), NULL, NULL)
INSERT [dbo].[PersonalDistrito] ([IdPersonalDistrito], [Nombre], [Apellido], [Cedula], [IdDepartamento], [IdDistrito], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (4, N'Karen', N'Perez', N'01010101010', 3, 1, 1, CAST(N'2022-10-13T17:03:17.497' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[PersonalDistrito] OFF
GO
SET IDENTITY_INSERT [dbo].[Asignaturas] ON 

INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (1, N'Matemáticas', 1, CAST(N'2022-10-13T17:04:11.407' AS DateTime), NULL, NULL)
INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (2, N'Lengua Española', 1, CAST(N'2022-10-13T17:04:20.313' AS DateTime), NULL, NULL)
INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (3, N'Ciencias Naturales', 1, CAST(N'2022-10-13T17:04:29.650' AS DateTime), NULL, NULL)
INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (4, N'Ciencias Sociales', 1, CAST(N'2022-10-13T17:04:39.350' AS DateTime), NULL, NULL)
INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (5, N'Química', 1, CAST(N'2022-10-13T17:04:49.007' AS DateTime), NULL, NULL)
INSERT [dbo].[Asignaturas] ([IdAsignatura], [Nombre], [CreadoPor], [FechaCreado], [ModificadoPor], [FechaModificado]) VALUES (6, N'Biología', 1, CAST(N'2022-10-13T17:04:54.040' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Asignaturas] OFF
GO
