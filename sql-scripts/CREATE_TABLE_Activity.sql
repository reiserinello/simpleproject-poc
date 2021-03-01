USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 01.03.2021 22:14:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity_name] [varchar](50) NOT NULL,
	[Planned_startdate] [datetime] NOT NULL,
	[Planned_enddate] [datetime] NOT NULL,
	[Startdate] [datetime] NULL,
	[Enddate] [datetime] NULL,
	[Activity_progress] [int] NOT NULL,
	[Activity_documents_link] [varchar](250) NULL,
	[Project_phase_id] [int] NOT NULL,
	[Employee_id] [int] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Employee] FOREIGN KEY([Employee_id])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Employee]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Project_phase] FOREIGN KEY([Project_phase_id])
REFERENCES [dbo].[Project_phase] ([Id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Project_phase]
GO

