USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 06.02.2021 17:02:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Project_name] [varchar](50) NOT NULL,
	[Project_description] [varchar](250) NULL,
	[Approval_date] [date] NULL,
	[Priority] [varchar](50) NOT NULL,
	[Project_state] [varchar](50) NOT NULL,
	[Planned_startdate] [date] NULL,
	[Planned_enddate] [date] NULL,
	[Startdate] [date] NULL,
	[Enddate] [date] NULL,
	[Project_manager] [varchar](50) NOT NULL,
	[Project_progress] [int] NOT NULL,
	[Project_documents_link] [varchar](250) NULL,
	[Project_method_id] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Project_method] FOREIGN KEY([Project_method_id])
REFERENCES [dbo].[Project_method] ([Id])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Project_method]
GO
