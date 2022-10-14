USE [master]
GO
/****** Object:  Database [DWDistrito0503]    Script Date: 10/6/2022 6:22:48 PM ******/
CREATE DATABASE [DWDistrito0503]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DWDistrito0503', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DWDistrito0503.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DWDistrito0503_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DWDistrito0503_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DWDistrito0503] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DWDistrito0503].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DWDistrito0503] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DWDistrito0503] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DWDistrito0503] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DWDistrito0503] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DWDistrito0503] SET ARITHABORT OFF 
GO
ALTER DATABASE [DWDistrito0503] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DWDistrito0503] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DWDistrito0503] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DWDistrito0503] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DWDistrito0503] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DWDistrito0503] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DWDistrito0503] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DWDistrito0503] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DWDistrito0503] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DWDistrito0503] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DWDistrito0503] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DWDistrito0503] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DWDistrito0503] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DWDistrito0503] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DWDistrito0503] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DWDistrito0503] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DWDistrito0503] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DWDistrito0503] SET RECOVERY FULL 
GO
ALTER DATABASE [DWDistrito0503] SET  MULTI_USER 
GO
ALTER DATABASE [DWDistrito0503] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DWDistrito0503] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DWDistrito0503] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DWDistrito0503] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DWDistrito0503] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DWDistrito0503] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DWDistrito0503', N'ON'
GO
ALTER DATABASE [DWDistrito0503] SET QUERY_STORE = OFF
GO
USE [DWDistrito0503]
GO
/****** Object:  Table [dbo].[AnioEscolar]    Script Date: 10/6/2022 6:22:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnioEscolar](
	[IdAnioEscolar] [int] IDENTITY(1,1) NOT NULL,
	[Anio] [nvarchar](20) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAnioEscolar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Archivos]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Archivos](
	[IdArchivo] [int] IDENTITY(1,1) NOT NULL,
	[NombreArchivo] [nvarchar](150) NULL,
	[Fecha] [datetime] NULL,
	[Ruta] [nvarchar](255) NULL,
	[IdEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchivosDetalle]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchivosDetalle](
	[IdArchivoDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdArchivo] [int] NULL,
	[Nombre] [nvarchar](150) NULL,
	[Estado] [nvarchar](150) NULL,
	[Modalidad] [nvarchar](255) NULL,
	[FechaNacimiento] [datetime] NULL,
	[Condicion] [nvarchar](255) NULL,
	[Curso] [nvarchar](255) NULL,
	[IdEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArchivoDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaturas](
	[IdAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CentrosEducativos]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CentrosEducativos](
	[IdCentroEducativo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](5) NULL,
	[IdTipoCentro] [int] NOT NULL,
	[IdDistrito] [int] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCentroEducativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Condiciones]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Condiciones](
	[IdCondicion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCondicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[IdSeccion] [int] NULL,
	[IdNivel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[IdDistrito] [int] NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distritos]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distritos](
	[IdDistrito] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[IdProvincia] [int] NULL,
	[IdMunicipio] [int] NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edades]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edades](
	[IdEdad] [int] IDENTITY(1,1) NOT NULL,
	[RangoEdad] [nvarchar](5) NULL,
	[Edad] [varchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEdad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Apellido] [nvarchar](255) NULL,
	[IDSigerd] [nvarchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
	[Sexo] [char](1) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstudiantesTipo]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstudiantesTipo](
	[IdEstudianteTipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudianteTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FactInscripcion]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactInscripcion](
	[IdFactInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdEstudianteTipo] [int] NULL,
	[IdModalidadTipo] [int] NULL,
	[IdFecha] [nvarchar](10) NULL,
	[IdAnioEscolar] [int] NULL,
	[IdCurso] [int] NULL,
	[IdProfesor] [int] NULL,
	[IdEdad] [int] NULL,
	[IdCondicion] [int] NULL,
	[IdCentro] [int] NULL,
	[ImporteInscripcion] [int] NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalidadesTipo]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalidadesTipo](
	[IdModalidadTipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdModalidadTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipios]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipios](
	[IdMunicipio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[IdProvincia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Niveles]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Niveles](
	[IdNivel] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalCentro]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalCentro](
	[IdPersonalCentro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Apellido] [nvarchar](255) NULL,
	[Cedula] [nvarchar](11) NULL,
	[IdDepartamento] [int] NULL,
	[IdCentro] [int] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPersonalCentro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDistrito]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDistrito](
	[IdPersonalDistrito] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Apellido] [nvarchar](255) NULL,
	[Cedula] [nvarchar](11) NULL,
	[IdDepartamento] [int] NULL,
	[IdDistrito] [int] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPersonalDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[IdProfesor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Apellido] [nvarchar](255) NULL,
	[Cedula] [nvarchar](11) NULL,
	[IdAsignatura] [int] NULL,
	[IdCentro] [int] NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[IdProvincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Secciones]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secciones](
	[IdSeccion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSeccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiempo]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiempo](
	[IdFecha] [nvarchar](10) NOT NULL,
	[Fecha] [datetime] NULL,
	[Dia] [nvarchar](2) NULL,
	[Mes] [nvarchar](2) NULL,
	[Anio] [nvarchar](4) NULL,
	[CreadoPor] [int] NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[FechaModificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCentro]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCentro](
	[IdTipoCentro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoCentro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[FechaCreado] [datetime] NOT NULL,
	[FechaModificado] [datetime] NULL,
	[Contrasena] [nvarchar](255) NULL,
	[rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValidacionData]    Script Date: 10/6/2022 6:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValidacionData](
	[IdValidacion] [int] IDENTITY(1,1) NOT NULL,
	[IdArchivo] [int] NULL,
	[IdArchivoDetalle] [int] NULL,
	[IdEstado] [int] NULL,
	[Comment] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdValidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnioEscolar] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Asignaturas] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[CentrosEducativos] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Condiciones] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Departamentos] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Distritos] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Estados] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Estudiantes] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[FactInscripcion] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[PersonalCentro] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[PersonalDistrito] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Profesores] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Tiempo] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaCreado]
GO
ALTER TABLE [dbo].[AnioEscolar]  WITH CHECK ADD  CONSTRAINT [FK_CreadoAnioEscolar] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[AnioEscolar] CHECK CONSTRAINT [FK_CreadoAnioEscolar]
GO
ALTER TABLE [dbo].[AnioEscolar]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoAnioEscolar] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[AnioEscolar] CHECK CONSTRAINT [FK_ModificadoAnioEscolar]
GO
ALTER TABLE [dbo].[Archivos]  WITH CHECK ADD  CONSTRAINT [FK_FileEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([IdEstado])
GO
ALTER TABLE [dbo].[Archivos] CHECK CONSTRAINT [FK_FileEstado]
GO
ALTER TABLE [dbo].[ArchivosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Archivo] FOREIGN KEY([IdArchivo])
REFERENCES [dbo].[Archivos] ([IdArchivo])
GO
ALTER TABLE [dbo].[ArchivosDetalle] CHECK CONSTRAINT [FK_Archivo]
GO
ALTER TABLE [dbo].[ArchivosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ArchivoDetalleEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([IdEstado])
GO
ALTER TABLE [dbo].[ArchivosDetalle] CHECK CONSTRAINT [FK_ArchivoDetalleEstado]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_CreadoAsignatura] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_CreadoAsignatura]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoAsignatura] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_ModificadoAsignatura]
GO
ALTER TABLE [dbo].[CentrosEducativos]  WITH CHECK ADD  CONSTRAINT [FK_CentroDistrito] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distritos] ([IdDistrito])
GO
ALTER TABLE [dbo].[CentrosEducativos] CHECK CONSTRAINT [FK_CentroDistrito]
GO
ALTER TABLE [dbo].[CentrosEducativos]  WITH CHECK ADD  CONSTRAINT [FK_CreadoCentro] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[CentrosEducativos] CHECK CONSTRAINT [FK_CreadoCentro]
GO
ALTER TABLE [dbo].[CentrosEducativos]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoCentro] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[CentrosEducativos] CHECK CONSTRAINT [FK_ModificadoCentro]
GO
ALTER TABLE [dbo].[CentrosEducativos]  WITH CHECK ADD  CONSTRAINT [FK_TipoCentro] FOREIGN KEY([IdTipoCentro])
REFERENCES [dbo].[TipoCentro] ([IdTipoCentro])
GO
ALTER TABLE [dbo].[CentrosEducativos] CHECK CONSTRAINT [FK_TipoCentro]
GO
ALTER TABLE [dbo].[Condiciones]  WITH CHECK ADD  CONSTRAINT [FK_CreadoCondiciones] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Condiciones] CHECK CONSTRAINT [FK_CreadoCondiciones]
GO
ALTER TABLE [dbo].[Condiciones]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoCondiciones] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Condiciones] CHECK CONSTRAINT [FK_ModificadoCondiciones]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_CursoNivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Niveles] ([IdNivel])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_CursoNivel]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_CursoSeccion] FOREIGN KEY([IdSeccion])
REFERENCES [dbo].[Secciones] ([IdSeccion])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_CursoSeccion]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [FK_CreadoDpto] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [FK_CreadoDpto]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [FK_DistritoDpto] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distritos] ([IdDistrito])
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [FK_DistritoDpto]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoDpto] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [FK_ModificadoDpto]
GO
ALTER TABLE [dbo].[Distritos]  WITH CHECK ADD  CONSTRAINT [FK_CreadoDistrito] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Distritos] CHECK CONSTRAINT [FK_CreadoDistrito]
GO
ALTER TABLE [dbo].[Distritos]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoDistrito] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Distritos] CHECK CONSTRAINT [FK_ModificadoDistrito]
GO
ALTER TABLE [dbo].[Distritos]  WITH CHECK ADD  CONSTRAINT [FK_MunicipioDistrito] FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipios] ([IdMunicipio])
GO
ALTER TABLE [dbo].[Distritos] CHECK CONSTRAINT [FK_MunicipioDistrito]
GO
ALTER TABLE [dbo].[Distritos]  WITH CHECK ADD  CONSTRAINT [FK_ProvinciaDistrito] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO
ALTER TABLE [dbo].[Distritos] CHECK CONSTRAINT [FK_ProvinciaDistrito]
GO
ALTER TABLE [dbo].[Estados]  WITH CHECK ADD  CONSTRAINT [FK_CreadoEstado] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Estados] CHECK CONSTRAINT [FK_CreadoEstado]
GO
ALTER TABLE [dbo].[Estados]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoEstado] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Estados] CHECK CONSTRAINT [FK_ModificadoEstado]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_CreadoEstudiante] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [FK_CreadoEstudiante]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoEstudiante] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [FK_ModificadoEstudiante]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_AnioEscolar] FOREIGN KEY([IdAnioEscolar])
REFERENCES [dbo].[AnioEscolar] ([IdAnioEscolar])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_AnioEscolar]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Condicion] FOREIGN KEY([IdCondicion])
REFERENCES [dbo].[Condiciones] ([IdCondicion])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Condicion]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_CreadoInscripcion] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_CreadoInscripcion]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Cursos] ([IdCurso])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Curso]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Edad] FOREIGN KEY([IdEdad])
REFERENCES [dbo].[Edades] ([IdEdad])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Edad]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiantes] ([IdEstudiante])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Estudiante]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_EstudianteTipo] FOREIGN KEY([IdEstudianteTipo])
REFERENCES [dbo].[EstudiantesTipo] ([IdEstudianteTipo])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_EstudianteTipo]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Fecha] FOREIGN KEY([IdFecha])
REFERENCES [dbo].[Tiempo] ([IdFecha])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Fecha]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_InscripcionCentro] FOREIGN KEY([IdCentro])
REFERENCES [dbo].[CentrosEducativos] ([IdCentroEducativo])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_InscripcionCentro]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_ModalidadTipo] FOREIGN KEY([IdModalidadTipo])
REFERENCES [dbo].[ModalidadesTipo] ([IdModalidadTipo])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_ModalidadTipo]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoInscripcion] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_ModificadoInscripcion]
GO
ALTER TABLE [dbo].[FactInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Profesor] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesores] ([IdProfesor])
GO
ALTER TABLE [dbo].[FactInscripcion] CHECK CONSTRAINT [FK_Profesor]
GO
ALTER TABLE [dbo].[Municipios]  WITH CHECK ADD  CONSTRAINT [FK_ProvinciaMunicipio] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO
ALTER TABLE [dbo].[Municipios] CHECK CONSTRAINT [FK_ProvinciaMunicipio]
GO
ALTER TABLE [dbo].[PersonalCentro]  WITH CHECK ADD  CONSTRAINT [FK_CreadoPersonalC] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[PersonalCentro] CHECK CONSTRAINT [FK_CreadoPersonalC]
GO
ALTER TABLE [dbo].[PersonalCentro]  WITH CHECK ADD  CONSTRAINT [FK_DeptoCentro] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamentos] ([IdDepartamento])
GO
ALTER TABLE [dbo].[PersonalCentro] CHECK CONSTRAINT [FK_DeptoCentro]
GO
ALTER TABLE [dbo].[PersonalCentro]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoPersonalC] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[PersonalCentro] CHECK CONSTRAINT [FK_ModificadoPersonalC]
GO
ALTER TABLE [dbo].[PersonalCentro]  WITH CHECK ADD  CONSTRAINT [FK_PersonalCentro] FOREIGN KEY([IdCentro])
REFERENCES [dbo].[CentrosEducativos] ([IdCentroEducativo])
GO
ALTER TABLE [dbo].[PersonalCentro] CHECK CONSTRAINT [FK_PersonalCentro]
GO
ALTER TABLE [dbo].[PersonalDistrito]  WITH CHECK ADD  CONSTRAINT [FK_CreadoPersonalD] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[PersonalDistrito] CHECK CONSTRAINT [FK_CreadoPersonalD]
GO
ALTER TABLE [dbo].[PersonalDistrito]  WITH CHECK ADD  CONSTRAINT [FK_DeptoDistrito] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamentos] ([IdDepartamento])
GO
ALTER TABLE [dbo].[PersonalDistrito] CHECK CONSTRAINT [FK_DeptoDistrito]
GO
ALTER TABLE [dbo].[PersonalDistrito]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoPersonalD] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[PersonalDistrito] CHECK CONSTRAINT [FK_ModificadoPersonalD]
GO
ALTER TABLE [dbo].[PersonalDistrito]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDistrito] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distritos] ([IdDistrito])
GO
ALTER TABLE [dbo].[PersonalDistrito] CHECK CONSTRAINT [FK_PersonalDistrito]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK_Area] FOREIGN KEY([IdAsignatura])
REFERENCES [dbo].[Asignaturas] ([IdAsignatura])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK_Area]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK_CreadoProfesor] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK_CreadoProfesor]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoProfesor] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK_ModificadoProfesor]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorDistrito] FOREIGN KEY([IdCentro])
REFERENCES [dbo].[CentrosEducativos] ([IdCentroEducativo])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK_ProfesorDistrito]
GO
ALTER TABLE [dbo].[Tiempo]  WITH CHECK ADD  CONSTRAINT [FK_CreadoTiempo] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tiempo] CHECK CONSTRAINT [FK_CreadoTiempo]
GO
ALTER TABLE [dbo].[Tiempo]  WITH CHECK ADD  CONSTRAINT [FK_ModificadoTiempo] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tiempo] CHECK CONSTRAINT [FK_ModificadoTiempo]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolUsuario] FOREIGN KEY([rol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_RolUsuario]
GO
ALTER TABLE [dbo].[ValidacionData]  WITH CHECK ADD  CONSTRAINT [FK_ArchivoDetValidate] FOREIGN KEY([IdArchivoDetalle])
REFERENCES [dbo].[ArchivosDetalle] ([IdArchivoDetalle])
GO
ALTER TABLE [dbo].[ValidacionData] CHECK CONSTRAINT [FK_ArchivoDetValidate]
GO
ALTER TABLE [dbo].[ValidacionData]  WITH CHECK ADD  CONSTRAINT [FK_EstadoValidate] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([IdEstado])
GO
ALTER TABLE [dbo].[ValidacionData] CHECK CONSTRAINT [FK_EstadoValidate]
GO
ALTER TABLE [dbo].[ValidacionData]  WITH CHECK ADD  CONSTRAINT [FK_FileValidate] FOREIGN KEY([IdArchivo])
REFERENCES [dbo].[Archivos] ([IdArchivo])
GO
ALTER TABLE [dbo].[ValidacionData] CHECK CONSTRAINT [FK_FileValidate]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [CH_Nacimiento] CHECK  (([FechaNacimiento]<=CONVERT([date],getdate())))
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [CH_Nacimiento]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [CH_Sexo] CHECK  (([Sexo]='F' OR [Sexo]='M'))
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [CH_Sexo]
GO
USE [master]
GO
ALTER DATABASE [DWDistrito0503] SET  READ_WRITE 
GO
