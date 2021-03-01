USE [simpleproject-poc]
GO

/****** Object:  Table [dbo].[External_cost]    Script Date: 01.03.2021 22:15:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[External_cost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Budget_cost] [int] NOT NULL,
	[Effective_cost] [int] NULL,
	[Deviation] [varchar](50) NULL,
	[Cost_type_id] [int] NOT NULL,
	[Activity_id] [int] NOT NULL,
 CONSTRAINT [PK_External_cost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[External_cost]  WITH CHECK ADD  CONSTRAINT [FK_External_cost_Activity] FOREIGN KEY([Activity_id])
REFERENCES [dbo].[Activity] ([Id])
GO

ALTER TABLE [dbo].[External_cost] CHECK CONSTRAINT [FK_External_cost_Activity]
GO

ALTER TABLE [dbo].[External_cost]  WITH CHECK ADD  CONSTRAINT [FK_External_cost_Cost_type] FOREIGN KEY([Cost_type_id])
REFERENCES [dbo].[Cost_type] ([Id])
GO

ALTER TABLE [dbo].[External_cost] CHECK CONSTRAINT [FK_External_cost_Cost_type]
GO

