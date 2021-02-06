USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Phase]    Script Date: 06.02.2021 17:02:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Phase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phase_name] [varchar](50) NOT NULL,
	[Project_method_id] [int] NOT NULL,
 CONSTRAINT [PK_Phase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Phase]  WITH CHECK ADD  CONSTRAINT [FK_Phase_Project_method] FOREIGN KEY([Project_method_id])
REFERENCES [dbo].[Project_method] ([Id])
GO

ALTER TABLE [dbo].[Phase] CHECK CONSTRAINT [FK_Phase_Project_method]
GO

