ALTER TABLE dbo.Customer ADD BestBeforeDate DateTime NOT NULL default GETDATE()
GO

UPDATE [dbo].[Customer]
SET [dbo].[Customer].[BestBeforeDate] = (SELECT DATEADD(day,(SELECT [BestBeforeDateType].[OffsetDays] FROM [dbo].[BestBeforeDateType] 
										 WHERE [dbo].[BestBeforeDateType].[Id] = [dbo].[Customer].[BestBeforeDateTypeId]), GETDATE()));

ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_BestBeforeDateType]
GO

ALTER TABLE [dbo].[Customer] DROP COLUMN BestBeforeDateTypeId
GO

ALTER TABLE [dbo].[Order] ADD BestBeforeDate DATETIME NOT NULL DEFAULT GETDATE()
GO

UPDATE [dbo].[Order]
SET [dbo].[Order].[BestBeforeDate] = (SELECT DATEADD(day,(SELECT [BestBeforeDateType].[OffsetDays] FROM [dbo].[BestBeforeDateType] 
									  WHERE [dbo].[BestBeforeDateType].[Id] = [dbo].[Order].[BestBeforeDateTypeId]), ISNULL([dbo].[Order].[SlaughterDate], GETDATE())));
GO

ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_BestBeforeDateType]
GO

ALTER TABLE [dbo].[Order] DROP CONSTRAINT [DF_Order_BestBeforeDateTypeId] 
GO

ALTER TABLE [dbo].[Order] DROP COLUMN BestBeforeDateTypeId
GO

DROP TABLE [dbo].[BestBeforeDateType]
GO