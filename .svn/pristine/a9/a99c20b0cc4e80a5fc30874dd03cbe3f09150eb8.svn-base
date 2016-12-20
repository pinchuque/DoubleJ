/* ColdWeight Table */
CREATE TABLE [dbo].[ColdWeight](
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [OrderId] [int] NOT NULL,
 [CreatedDate] [datetime] NOT NULL,
 [QualityGradeId] [int] NULL,
 [TotalCount] [int] NOT NULL DEFAULT((0)),
 [TotalWeight] [decimal](18, 2) NOT NULL DEFAULT((0)),
 CONSTRAINT [PK_ColdWeight] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ColdWeight]  WITH CHECK ADD  CONSTRAINT [FK_ColdWeight_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[ColdWeight] CHECK CONSTRAINT [FK_ColdWeight_Order]
GO

ALTER TABLE [dbo].[ColdWeight]  WITH CHECK ADD  CONSTRAINT [FK_ColdWeight_QualityGrade] FOREIGN KEY([QualityGradeId])
REFERENCES [dbo].[QualityGrade] ([Id])
GO

ALTER TABLE [dbo].[ColdWeight] CHECK CONSTRAINT [FK_ColdWeight_QualityGrade]
GO


CREATE TABLE [dbo].[ColdWeightDetail](
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [ColdWeightId] [int] NOT NULL,
 [CreatedDate] [datetime] NOT NULL,
 [Weight] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ColdWeightDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ColdWeightDetail]  WITH CHECK ADD  CONSTRAINT [FK_ColdWeightDetail_ColdWeight] FOREIGN KEY([ColdWeightId])
REFERENCES [dbo].[ColdWeight] ([Id])
GO

ALTER TABLE [dbo].[ColdWeightDetail] CHECK CONSTRAINT [FK_ColdWeightDetail_ColdWeight]
GO