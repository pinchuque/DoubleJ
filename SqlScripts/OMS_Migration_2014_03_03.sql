INSERT INTO [dbo].[SiteNavigation]([Id],[Name],[Url],[SortOrder],[IsActive])
   VALUES(7,'Fulfillment','~/Internal/Fulfillment',7,1)
GO

ALTER TABLE [dbo].[Label] DROP COLUMN FdaBugPath
GO