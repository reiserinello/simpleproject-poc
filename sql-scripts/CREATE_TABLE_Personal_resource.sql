USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[Personal_resource]    Script Date: 06.02.2021 17:03:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personal_resource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Budget_time] [int] NOT NULL,
	[Effective_time] [int] NULL,
	[Deviation] [varchar](50) NULL,
	[Function_id] [int] NOT NULL,
	[Activity_id] [int] NOT NULL,
 CONSTRAINT [PK_Personal_resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Personal_resource]  WITH CHECK ADD  CONSTRAINT [FK_Personal_resource_Activity] FOREIGN KEY([Activity_id])
REFERENCES [dbo].[Activity] ([Id])
GO

ALTER TABLE [dbo].[Personal_resource] CHECK CONSTRAINT [FK_Personal_resource_Activity]
GO

ALTER TABLE [dbo].[Personal_resource]  WITH CHECK ADD  CONSTRAINT [FK_Personal_resource_Function] FOREIGN KEY([Function_id])
REFERENCES [dbo].[Function] ([Id])
GO

ALTER TABLE [dbo].[Personal_resource] CHECK CONSTRAINT [FK_Personal_resource_Function]
GO

