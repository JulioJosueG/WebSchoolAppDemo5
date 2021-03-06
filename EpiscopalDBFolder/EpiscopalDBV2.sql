USE [EpiscopalDB]
GO
/****** Object:  Table [dbo].[Ages]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ages](
	[age_id] [int] NOT NULL,
	[age_range] [varchar](20) NULL,
 CONSTRAINT [PK_ages] PRIMARY KEY CLUSTERED 
(
	[age_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dates]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dates](
	[date_id] [int] NOT NULL,
	[day] [int] NULL,
	[month] [int] NULL,
	[year] [int] NULL,
 CONSTRAINT [PK_dates] PRIMARY KEY CLUSTERED 
(
	[date_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fact_enrolled]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fact_enrolled](
	[id_enrolled] [int] NOT NULL,
	[student_id] [int] NOT NULL,
	[student_type_id] [int] NOT NULL,
	[date_id] [int] NOT NULL,
	[school_year_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[age_id] [int] NOT NULL,
 CONSTRAINT [PK_fact_enrolled] PRIMARY KEY CLUSTERED 
(
	[id_enrolled] ASC,
	[student_id] ASC,
	[student_type_id] ASC,
	[date_id] ASC,
	[school_year_id] ASC,
	[grade_id] ASC,
	[age_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[grade_id] [int] NOT NULL,
	[grade_name_id] [int] NOT NULL,
	[section_id] [int] NOT NULL,
	[level_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
 CONSTRAINT [PK_grades] PRIMARY KEY CLUSTERED 
(
	[grade_id] ASC,
	[grade_name_id] ASC,
	[section_id] ASC,
	[level_id] ASC,
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades_name]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades_name](
	[grade_name_id] [int] NOT NULL,
	[grade_name] [varchar](250) NULL,
 CONSTRAINT [PK_Grades_name] PRIMARY KEY CLUSTERED 
(
	[grade_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Levels]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levels](
	[level_id] [int] NOT NULL,
	[level_name] [varchar](250) NULL,
 CONSTRAINT [PK_levels] PRIMARY KEY CLUSTERED 
(
	[level_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modality_types]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modality_types](
	[modality_id] [int] NOT NULL,
	[modality_name] [varchar](250) NULL,
 CONSTRAINT [PK_modalities] PRIMARY KEY CLUSTERED 
(
	[modality_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_years]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_years](
	[school_year_id] [int] NOT NULL,
	[year] [varchar](250) NULL,
 CONSTRAINT [PK_School_years] PRIMARY KEY CLUSTERED 
(
	[school_year_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[section_id] [int] NOT NULL,
	[section_name] [varchar](250) NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[section_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_types]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_types](
	[student_type_id] [int] NOT NULL,
	[student_type_name] [varchar](250) NULL,
 CONSTRAINT [PK_students_type] PRIMARY KEY CLUSTERED 
(
	[student_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[student_id] [int] NOT NULL,
	[student_name] [varchar](250) NULL,
	[student_lastname] [varchar](250) NULL,
	[date_of_birth] [date] NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 3/10/2022 11:45:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [int] NOT NULL,
	[teacher_name] [varchar](250) NULL,
 CONSTRAINT [PK_teachers] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
