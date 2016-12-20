ALTER TABLE [dbo].[Label] ADD [JulianProductionDate] varchar(3) NULL
GO
UPDATE [dbo].[Label] SET [JulianProductionDate] = RIGHT('000' + CAST(DATEPART(dy, CreatedDate) AS varchar(3)),3)
GO