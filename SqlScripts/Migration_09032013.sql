ALTER TABLE [dbo].[Customer] 
ADD [BagLabel] NVARCHAR(200) NOT NULL DEFAULT ('')
GO

ALTER TABLE [dbo].[Customer] 
ADD [BoxLabel] NVARCHAR(200) NOT NULL DEFAULT ('')
GO

ALTER TABLE [dbo].[Label] 
ADD [LabelFile] NVARCHAR(200) NOT NULL DEFAULT ('')
GO
