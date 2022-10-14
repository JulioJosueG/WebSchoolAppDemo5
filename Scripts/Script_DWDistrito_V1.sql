--CREATE DATABASE DWDistrito0503

USE DWDistrito0503

--------------------------------CREACIÓN DE TABLAS--------------------------------------------

----------------------------------TABLA USUARIOS---------------------------------------------
CREATE TABLE Usuarios
(
IdUsuario int primary key identity(1,1),
Nombre nvarchar(255) not null,
Apellido nvarchar(255) not null,
FechaCreado datetime not null default getdate(),
FechaModificado datetime
)

--insert into Usuarios(Nombre, Apellido) values ('Abigail', 'Rodriguez')

--------------------------------TABLA ESTADOS---------------------------------

CREATE TABLE Estados(
	IdEstado int primary key identity(1,1),
	Nombre nvarchar(150),
	CreadoPor int not null,
	constraint FK_CreadoEstado foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoEstado foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

--insert into Estados(Nombre,CreadoPor) values ('Activo',1),
--('Eliminado',1), ('Modificado',1)


---------------------------------TABLA PROVINCIAS---------------------------------------------
CREATE TABLE Provincias(
	IdProvincia int primary key identity(1,1),
	Nombre nvarchar(255)
)


---------------------------------TABLA MUNICIPIO---------------------------------------------
CREATE TABLE Municipios(
	IdMunicipio int primary key identity(1,1),
	Nombre nvarchar(255),
	IdProvincia int,
	constraint [FK_ProvinciaMunicipio] Foreign key (IdProvincia) references Provincias(IdProvincia)
)


--------------------------------TABLA DISTRITO----------------------------------------------
CREATE TABLE Distritos(
	IdDistrito int primary key identity(1,1),
	Codigo varchar(20) not null,
	IdProvincia int,
	constraint [FK_ProvinciaDistrito] Foreign key (IdProvincia) references Provincias(IdProvincia),
	IdMunicipio int,
	constraint [FK_MunicipioDistrito] Foreign key (IdMunicipio) references Municipios(IdMunicipio),
	CreadoPor int not null,
	constraint FK_CreadoDistrito foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoDistrito foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

---------------------------------TABLA TIPO CENTRO---------------------------------------------
CREATE TABLE Departamentos(
	IdDepartamento int primary key identity(1,1),
	Nombre nvarchar(255),
	IdDistrito int,
	constraint [FK_DistritoDpto] Foreign key (IdDistrito) references Distritos(IdDistrito),
	CreadoPor int not null,
	constraint FK_CreadoDpto foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoDpto foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

-------------------------------TABLA PERSONAL DISTRITO-----------------------------------------------

CREATE TABLE PersonalDistrito(
	IdPersonalDistrito int primary key identity(1,1),
	Nombre nvarchar(255),
	Apellido nvarchar(255),
	Cedula nvarchar(11),
	IdDepartamento int,
	constraint [FK_DeptoDistrito] foreign key (IdDepartamento) references Departamentos(IdDepartamento),
	IdDistrito int not null,
	constraint [FK_PersonalDistrito] Foreign key (IdDistrito) references Distritos(IdDistrito),
	CreadoPor int not null,
	constraint FK_CreadoPersonalD foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoPersonalD foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

---------------------------------TABLA TIPO CENTRO (Privado, Semi oficial, oficial)---------------------------------------------
CREATE TABLE TipoCentro(
	IdTipoCentro int primary key identity(1,1),
	Nombre nvarchar(255)
)

-------------------------------TABLA CENTROS-----------------------------------------------

CREATE TABLE CentrosEducativos(
	IdCentroEducativo int primary key identity(1,1),
	Nombre nvarchar(5),
	IdTipoCentro int not null,
	constraint [FK_TipoCentro] Foreign key (IdTipoCentro) references TipoCentro(IdTipoCentro),
	IdDistrito int not null,
	constraint [FK_CentroDistrito] Foreign key (IdDistrito) references Distritos(IdDistrito),
	CreadoPor int not null,
	constraint FK_CreadoCentro foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoCentro foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

-------------------------------TABLA PERSONAL DISTRITO-----------------------------------------------

CREATE TABLE PersonalCentro(
	IdPersonalCentro int primary key identity(1,1),
	Nombre nvarchar(255),
	Apellido nvarchar(255),
	Cedula nvarchar(11),
	IdDepartamento int,
	constraint [FK_DeptoCentro] foreign key (IdDepartamento) references Departamentos(IdDepartamento),
	IdCentro int not null,
	constraint [FK_PersonalCentro] Foreign key (IdCentro) references CentrosEducativos(IdCentroEducativo),
	CreadoPor int not null,
	constraint FK_CreadoPersonalC foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoPersonalC foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

--------------------------------TABLA ESTUDIANTES----------------------------------------------

create table Estudiantes(
	IdEstudiante int primary key identity(1,1),
	Nombre nvarchar(255),
	Apellido nvarchar(255),
	IDSigerd nvarchar(100),
	FechaNacimiento datetime,
	Sexo Char,
	CreadoPor int not null,
	constraint FK_CreadoEstudiante foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoEstudiante foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

--Restriccion para limitar los literales de sexo y fecha de nacimiento de los estudiantes
--alter table Estudiantes
--add constraint CH_Nacimiento check([FechaNacimiento] <= convert(date, getdate())),
--constraint CH_Sexo check(Sexo = 'F' or Sexo = 'M')

---------------------------------TABLA EDADES---------------------------------------------------

CREATE TABLE Edades(
	IdEdad int primary key identity(1,1),
	RangoEdad nvarchar(5),
	Edad varchar(2)
)

----------------------------------TABLA DE MODALIDADES--------------------------------------
--Las modalidades son: presencial, semipresencial, virtual y todas.
--------------------------------------------------------------------------------------------

CREATE TABLE ModalidadesTipo(
	IdModalidadTipo int primary key identity(1,1),
	Nombre nvarchar(150)
)


-------------------------------TABLA CONDICION--------------------------------
--Las condiciones son: Inscrito y retirado.
------------------------------------------------------------------------------
CREATE TABLE Condiciones(
	IdCondicion int primary key identity(1,1),
	Nombre nvarchar(150),
	CreadoPor int not null,
	constraint FK_CreadoCondiciones foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoCondiciones foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

-------------------------------------TABLA TIPO ESTUDIANTES---------------------------------------------
--Los tipos de estudiantes son: nuevo ingreso, reinscrito
--------------------------------------------------------------------------------------------------------
CREATE TABLE EstudiantesTipo(
	IdEstudianteTipo int primary key identity(1,1),
	Nombre nvarchar(150)
)


-------------------------------------TABLA ANIO ESCOLAR--------------------------------------------------
--El anio escolar para el que se inscribe el alumno (2021-2022 es un ejemplo)
---------------------------------------------------------------------------------------------------------

CREATE TABLE AnioEscolar(
	IdAnioEscolar int primary key identity(1,1),
	Anio nvarchar(20),
	CreadoPor int not null,
	constraint FK_CreadoAnioEscolar foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoAnioEscolar foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)


------------------------------------TABLA TIEMPO/FECHA------------------------------------------------------
CREATE TABLE Tiempo(
	IdFecha nvarchar(10) primary key,
	Fecha datetime,
	Dia nvarchar(2),
	Mes nvarchar(2),
	Anio nvarchar(4),
	CreadoPor int not null,
	constraint FK_CreadoTiempo foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoTiempo foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

---------------------------------TABLA AREAS (ASIGNATURAS)---------------------------------------------
CREATE TABLE Asignaturas(
	IdAsignatura int primary key identity(1,1),
	Nombre nvarchar(255),
	CreadoPor int not null,
	constraint FK_CreadoAsignatura foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoAsignatura foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)


---------------------------------------------TABLA PROFESORES-------------------------------------------------

CREATE TABLE Profesores(
	IdProfesor int primary key identity(1,1),
	Nombre nvarchar(255),
	Apellido nvarchar(255),
	Cedula nvarchar(11),
	IdAsignatura int,
	constraint [FK_Area] foreign key (IdAsignatura) references Asignaturas(IdAsignatura),
	IdCentro int,
	constraint [FK_ProfesorDistrito] Foreign key (IdCentro) references CentrosEducativos(IdCentroEducativo),
	CreadoPor int not null,
	constraint FK_CreadoProfesor foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoProfesor foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)

---------------------------------TABLA SECCIONES---------------------------------------------
CREATE TABLE Secciones(
	IdSeccion int primary key identity(1,1),
	Nombre nvarchar(255)
)

---------------------------------TABLA NIVELS---------------------------------------------
CREATE TABLE Niveles(
	IdNivel int primary key identity(1,1),
	Nombre nvarchar(255)
)

-----------------------------------------------TABLA GRADOS/CURSOS---------------------------------------------

CREATE TABLE Cursos(
	IdCurso int primary key identity(1,1),
	Nombre nvarchar(255),
	IdSeccion int,
	IdNivel int,
	constraint [FK_CursoSeccion] foreign key (IdSeccion) references Secciones(IdSeccion),
	constraint [FK_CursoNivel] Foreign key (IdNivel) references Niveles(IdNivel)
)


-----------------------------------------TABLA DE HECHO----------------------------------------------------------

CREATE TABLE FactInscripcion(
	IdFactInscripcion int primary key identity(1,1),
	IdEstudiante int not null,
	constraint [FK_Estudiante] foreign key(IdEstudiante) references Estudiantes(IdEstudiante),
	IdEstudianteTipo int,
	constraint [FK_EstudianteTipo] foreign key(IdEstudianteTipo) references EstudiantesTipo(IdEstudianteTipo),
	IdModalidadTipo int,
	constraint [FK_ModalidadTipo] foreign key(IdModalidadTipo) references ModalidadesTipo(IdModalidadTipo),
	IdFecha nvarchar(10),
	constraint [FK_Fecha] foreign key(IdFecha) references Tiempo(IdFecha),
	IdAnioEscolar int,
	constraint [FK_AnioEscolar] foreign key(IdAnioEscolar) references AnioEscolar(IdAnioEscolar),
	IdCurso int,
	constraint [FK_Curso] foreign key(IdCurso) references Cursos(IdCurso),
	IdProfesor int,
	constraint [FK_Profesor] foreign key(IdProfesor) references Profesores(IdProfesor),
	IdEdad int,
	constraint [FK_Edad] foreign key(IdEdad) references Edades(IdEdad),
	IdCondicion int,
	constraint [FK_Condicion] Foreign key (IdCondicion) references Condiciones(IdCondicion),
	IdCentro int,
	constraint [FK_InscripcionCentro] Foreign key (IdCentro) references CentrosEducativos(IdCentroEducativo),
	ImporteInscripcion int,
	CreadoPor int not null,
	constraint FK_CreadoInscripcion foreign key (CreadoPor) references Usuarios(IdUsuario),
	FechaCreado datetime not null default getdate(),
	ModificadoPor int,
	constraint FK_ModificadoInscripcion foreign key (ModificadoPor) references Usuarios(IdUsuario),	
	FechaModificado datetime
)



-------------------------------TABLA DE ARCHIVOS------------------------------------
CREATE TABLE Archivos(
	IdArchivo int primary key identity(1,1),
	NombreArchivo nvarchar(150),
	Fecha Datetime,
	Ruta nvarchar(255),
	IdEstado int,
	constraint [FK_FileEstado] Foreign key (IdEstado) references Estados(IdEstado)
)


CREATE TABLE ArchivosDetalle(
	IdArchivoDetalle int primary key identity(1,1),
	IdArchivo int,
	constraint [FK_Archivo] foreign key (IdArchivo) references Archivos(IdArchivo),
	Nombre nvarchar(150),
	Estado nvarchar(150),
	Modalidad nvarchar(255),
	FechaNacimiento Datetime,
	Condicion nvarchar(255),
	Curso nvarchar(255),
	IdEstado int,
	constraint [FK_ArchivoDetalleEstado] Foreign key (IdEstado) references Estados(IdEstado)
)



--VALIDATION TABLE
GO
CREATE TABLE ValidacionData(
	IdValidacion int primary key identity(1,1),
	IdArchivo int,
	constraint [FK_FileValidate] Foreign key (IdArchivo) references Archivos(IdArchivo),
	IdArchivoDetalle int,
	constraint [FK_ArchivoDetValidate] Foreign key (IdArchivoDetalle) references ArchivosDetalle(IdArchivoDetalle),
	IdEstado int,
	constraint [FK_EstadoValidate] Foreign key (IdEstado) references Estados(IdEstado),
	Comment nvarchar(255)
)
