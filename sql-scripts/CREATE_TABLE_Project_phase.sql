USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Project_phase]    Script Date: 05.03.2021 19:49:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_phase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phase_state] [varchar](50) NOT NULL,
	[Phase_progress] [int] NOT NULL,
	[Planned_startdate] [datetime] NULL,
	[Planned_enddate] [datetime] NULL,
	[Startdate] [datetime] NULL,
	[Enddate] [datetime] NULL,
	[Approval_date] [datetime] NULL,
	[Visum] [varchar](50) NULL,
	[Planned_reviewdate] [datetime] NULL,
	[Reviewdate] [datetime] NULL,
	[Phase_documents_link] [varchar](250) NULL,
	[Project_id] [int] NOT NULL,
	[Phase_id] [int] NOT NULL,
 CONSTRAINT [PK_Project_phase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Project_phase]  WITH CHECK ADD  CONSTRAINT [FK_Project_phase_Phase] FOREIGN KEY([Phase_id])
REFERENCES [dbo].[Phase] ([Id])
GO

ALTER TABLE [dbo].[Project_phase] CHECK CONSTRAINT [FK_Project_phase_Phase]
GO

ALTER TABLE [dbo].[Project_phase]  WITH CHECK ADD  CONSTRAINT [FK_Project_phase_Project] FOREIGN KEY([Project_id])
REFERENCES [dbo].[Project] ([Id])
GO

ALTER TABLE [dbo].[Project_phase] CHECK CONSTRAINT [FK_Project_phase_Project]
GO

