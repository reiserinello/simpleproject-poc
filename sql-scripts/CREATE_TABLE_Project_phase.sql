USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Project_phase]    Script Date: 06.02.2021 17:02:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_phase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phase_state] [varchar](50) NOT NULL,
	[Phase_progress] [int] NOT NULL,
	[Planned_startdate] [date] NULL,
	[Planned_enddate] [date] NULL,
	[Startdate] [date] NULL,
	[Enddate] [date] NULL,
	[Approval_date] [date] NULL,
	[Visum] [varchar](50) NULL,
	[Planned_reviewdate] [date] NULL,
	[Reviewdate] [date] NULL,
	[Phase_documents_link] [varchar](250) NULL,
	[Project_id] [int] NOT NULL,
	[Phase_id] [int] NOT NULL,
	[Milestone_id] [int] NOT NULL,
 CONSTRAINT [PK_Project_phase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Project_phase]  WITH CHECK ADD  CONSTRAINT [FK_Project_phase_Milestone] FOREIGN KEY([Milestone_id])
REFERENCES [dbo].[Milestone] ([Id])
GO

ALTER TABLE [dbo].[Project_phase] CHECK CONSTRAINT [FK_Project_phase_Milestone]
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

