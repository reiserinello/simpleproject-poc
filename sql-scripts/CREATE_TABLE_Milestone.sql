USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Milestone]    Script Date: 16.02.2021 13:56:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Milestone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Milestone_name] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Project_phase_id] [int] NOT NULL,
 CONSTRAINT [PK_Milestone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Milestone]  WITH CHECK ADD  CONSTRAINT [FK_Milestone_Project_phase] FOREIGN KEY([Project_phase_id])
REFERENCES [dbo].[Project_phase] ([Id])
GO

ALTER TABLE [dbo].[Milestone] CHECK CONSTRAINT [FK_Milestone_Project_phase]
GO

